﻿internal abstract class Component
{
    protected Component(Simulation simulation)
    {
        simulation.ClockEdge += OnClockEdge;
    }

    public abstract void OnClockEdge();
}