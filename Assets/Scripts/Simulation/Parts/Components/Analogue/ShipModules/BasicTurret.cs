using UnityEngine;

internal class BasicTurret : VisualisedComponent
{
    private readonly AnalogueWire bearingInput;
    private readonly Ship ship;
    private TurretVisualiser turretVisualiser;

    public BasicTurret(EngineEvents engineEvents, Simulation simulation, Ship ship, World world, AnalogueWire bearingInput) : base(engineEvents, simulation, ship, world)
    {
        this.ship = ship;
        this.bearingInput = bearingInput;
    }

    public override void OnClockEdge()
    {
        turretVisualiser.RotationInDegrees = bearingInput.SignalValue + ship.RotationInDegrees + 20.0f;
    }

    public override void CreateModuleView()
    {
        ModelView = Object.Instantiate(Resources.Load<GameObject>(ResourcePaths.BasicTurretResourcePath)) as GameObject;
        if (ModelView != null) turretVisualiser = ModelView.GetComponent<TurretVisualiser>();
    }
}