using UnityEngine;

internal class DigitalProbe : Component
{
    private readonly DigitalWire instrumentedDigitalWire;
    private readonly string probeName;
    private readonly Ship ship;

    public DigitalProbe(EngineEvents engineEvents, Simulation simulation, Ship ship, World world, string probeName,DigitalWire instrumentedDigitalWire) : base(simulation)
    {
        this.ship = ship;
        this.instrumentedDigitalWire = instrumentedDigitalWire;
        this.probeName = probeName;
    }

    public override void OnClockEdge()
    {
        Debug.Log(probeName + "Ship Id: " + ship.InstanceId + " probe value: " + instrumentedDigitalWire.SignalValue);
    }
}