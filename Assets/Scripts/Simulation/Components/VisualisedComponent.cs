using UnityEngine;

internal abstract class VisualisedComponent : Component
{
    private readonly EngineEvents engineEvents;
    private readonly Ship ship;
    protected GameObject ModelView;

    protected VisualisedComponent(EngineEvents engineEvents, Simulation simulation, Ship ship, World world) : base(engineEvents, simulation, ship, world)
    {
        this.engineEvents = engineEvents;
        this.ship = ship;
        engineEvents.OnStart += OnStart;
        engineEvents.OnUpdate += OnUpdate;
        //Todo - Need to tidy this up.
        engineEvents.OnGameEnd += Destroy;
        ship.OnShipDestroyed += Destroy;
    }

    public abstract void CreateModuleView();

    private void OnStart()
    {
        CreateModuleView();
    }

    private void OnUpdate()
    {
        ModelView.transform.position = new Vector3(ship.PositionX, ship.PositionY);
    }

    private void Destroy()
    {
        Object.Destroy(ModelView);
        engineEvents.OnStart -= OnStart;
        engineEvents.OnUpdate -= OnUpdate;
        engineEvents.OnGameEnd -= Destroy;
        ship.OnShipDestroyed -= Destroy;
    }
}