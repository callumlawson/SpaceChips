﻿using Assets.Scripts.Simulation;
using Assets.Scripts.Simulation.Components.Wires;
using Assets.Scripts.Simulation.GameState;
using UnityEngine;
using Component = Assets.Scripts.Simulation.Components.Component;

internal class DigitalProbe : Component
{
    private readonly DigitalWire instrumentedDigitalWire;
    private readonly string probeName;
    private readonly Ship ship;

    public DigitalProbe(EngineEvents engineEvents, Brain brain, Ship ship, World world, string probeName,DigitalWire instrumentedDigitalWire) : base()
    {
        this.ship = ship;
        this.instrumentedDigitalWire = instrumentedDigitalWire;
        this.probeName = probeName;
    }

    public override void OnClockEdge()
    {
        Debug.Log(probeName + "Ship Id: " + ship.ShipId + " probe value: " + instrumentedDigitalWire.SignalValue);
    }
}