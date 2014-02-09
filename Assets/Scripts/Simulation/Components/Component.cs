public abstract class Component
{
    //TODO rename as component is already a unity class
    protected Component(Simulation simulation)
    {
        simulation.ClockEdge += OnClockEdge;
    }

    public abstract void OnClockEdge();
}