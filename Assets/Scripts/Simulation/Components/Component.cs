using System;

public abstract class Component
{
    public event Action OnComponentDestroyed;
    //TODO rename as component is already a unity class
    protected Component(Simulation simulation, Ship ship)
    {
        simulation.ClockEdge += OnClockEdge;
        ship.OnShipDestroyed += Destroy;
    }

    protected void Destroy()
    {
        if (OnComponentDestroyed != null)
        {
            OnComponentDestroyed();
        }
    }

    public abstract void OnClockEdge();
}