using System.Linq;
using UnityEngine;

//Todo - Purge code of evil
internal class BasicTurret : VisualisedComponent
{
    private readonly AnalogueWire bearingInput;
    private TurretVisualiser turretVisualiser;

    private const int LazerCooldownDuration = 40;
    private int currentLazerCooldown = LazerCooldownDuration;

    public BasicTurret(EngineEvents engineEvents, Simulation simulation, Ship ship, World world, AnalogueWire bearingInput) : base(engineEvents, simulation, ship, world)
    {
        this.bearingInput = bearingInput;
    }

    public override void OnClockEdge()
    {
        TryFireLazer();
        UpdateModuleView();
    }

    private void TryFireLazer()
    {
        if (currentLazerCooldown != 0)
        {
            currentLazerCooldown -= 1;
            return;
        }

        currentLazerCooldown = LazerCooldownDuration;

        var turretPosition = new Vector2(ModelView.transform.position.x, ModelView.transform.position.y);
        var shotDirection = SpaceMath.BearingToNormalizedVector2(bearingInput.SignalValue + Ship.RotationInDegrees);

        turretVisualiser.FireLazer(turretPosition, turretPosition + shotDirection*30.0f);

        var potentialHit = Physics2D.RaycastAll(new Vector2(Ship.PositionX, Ship.PositionY), shotDirection)
                                    .FirstOrDefault(hit => hit.transform.gameObject.GetInstanceID() != Ship.InstanceId);

        // ReSharper disable ConditionIsAlwaysTrueOrFalse
        if (potentialHit != null)
        // ReSharper restore ConditionIsAlwaysTrueOrFalse
        {
            if (potentialHit.transform != null)
            {
                var targetShip = World.GetShipByShipId(potentialHit.transform.gameObject.GetInstanceID());
                if (targetShip != null)
                {
                    targetShip.Destroy();
                    
                    turretVisualiser.FireLazer(new Vector2(turretPosition.x, turretPosition.y), new Vector2(potentialHit.point.x, potentialHit.point.y));
                }
            }
        }
    }

    private void UpdateModuleView()
    {
        turretVisualiser.RotationInDegrees = bearingInput.SignalValue + Ship.RotationInDegrees;
    }

    public override void CreateModuleView()
    {
        ModelView = Object.Instantiate(Resources.Load<GameObject>(ResourcePaths.BasicTurretResourcePath)) as GameObject;
        if (ModelView != null) turretVisualiser = ModelView.GetComponent<TurretVisualiser>();
    }
}