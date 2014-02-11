using UnityEngine;
using System;
using System.Linq;

//Todo - Purge code of evil
public class BasicTurret : Component
{
    public event Action LazerFired;
    public Vector2 TurretDirection;

    private readonly AnalogueWire bearingInput;
    private const int LazerCooldownDuration = 40;
    private int currentLazerCooldown = LazerCooldownDuration;
    private readonly Ship ship;
    private readonly World world;

    public BasicTurret(Simulation simulation, Ship ship, World world, AnalogueWire bearingInput) : base(simulation, ship)
    {
        this.world = world;
        this.ship = ship;
        this.bearingInput = bearingInput;
    }

    public override void OnClockEdge()
    {
        TryFireLazer();
    }

    private void TryFireLazer()
    {
        if (currentLazerCooldown != 0)
        {
            currentLazerCooldown -= 1;
            return;
        }
        currentLazerCooldown = LazerCooldownDuration;

        TurretDirection = SpaceMath.BearingToNormalizedVector2(bearingInput.SignalValue + ship.RotationInDegrees);
        LazerFired();

        //TODO - Physics via the world instead of breaking abstraction
        var potentialHit = Physics2D.RaycastAll(new Vector2(ship.PositionX, ship.PositionY), TurretDirection)
                                    .FirstOrDefault(hit => hit.transform.gameObject.GetInstanceID() != ship.InstanceId);

        if (potentialHit.transform != null)
        {
            var targetShip = world.GetShipByShipId(potentialHit.transform.gameObject.GetInstanceID());
            if (targetShip != null)
            {
                targetShip.Destroy();
            }
        }
    }
}