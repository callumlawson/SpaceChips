internal abstract class Component
{
    protected Ship Ship;
    protected World World;

    protected Component(EngineEvents engineEvents, Simulation simulation, Ship ship, World world)
    {
        Ship = ship;
        World = world;
        //Todo - unregister this!
        simulation.ClockEdge += OnClockEdge;
    }

    public abstract void OnClockEdge();
}