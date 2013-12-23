internal abstract class Component
{
    protected Ship Ship;
    protected World World;

    protected Component(Simulation simulation, Ship ship, World world)
    {
        Ship = ship;
        World = world;
        simulation.ClockEdge += OnClockEdge;
    }

    public abstract void OnClockEdge();
}