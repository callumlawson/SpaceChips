using UnityEngine;

internal class DigitalProbe : Component
{
    private readonly DigitalWire instrumentedDigitalWire;
    private readonly string probeName;

    public DigitalProbe(EngineEvents engineEvents, Simulation simulation, Ship ship, World world, string probeName,DigitalWire instrumentedDigitalWire) : base(engineEvents, simulation, ship, world)
    {
        this.instrumentedDigitalWire = instrumentedDigitalWire;
        this.probeName = probeName;
    }

    public override void OnClockEdge()
    {
        Debug.Log(probeName + "Ship Id: " + Ship.ShipId + " probe value: " + instrumentedDigitalWire.SignalValue);
    }
}