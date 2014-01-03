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
        engineEvents.OnGameEnd += OnGameEnd;
    }

    public abstract void CreateModuleView();

    private void OnStart()
    {
        CreateModuleView();
    }

    private void OnUpdate()
    {
        ModelView.transform.position = new Vector3(ship.X, ship.Y);
        CheckShipState();
    }

    //TODO Get rid of this evil
    private void CheckShipState()
    {
        if (!ship.IsAlive)
        {
            Destroy();
        }
    }

    private void OnGameEnd()
    {
        Destroy();
    }

    private void Destroy()
    {
        Object.Destroy(ModelView);
        engineEvents.OnStart -= OnStart;
        engineEvents.OnGameEnd -= OnGameEnd;
        engineEvents.OnUpdate -= OnUpdate;
    }
}