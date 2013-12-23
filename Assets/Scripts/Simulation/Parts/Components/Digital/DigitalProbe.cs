using UnityEngine;

internal class DigitalProbe : Component
{
    private readonly DigitalWire instrumentedDigitalWire;
    private readonly string probeName;

    public DigitalProbe(Simulation simulation, Ship ship, World world, string probeName,DigitalWire instrumentedDigitalWire) : base(simulation, ship, world)
    {
        this.instrumentedDigitalWire = instrumentedDigitalWire;
        this.probeName = probeName;
    }

    public override void OnClockEdge()
    {
        Debug.Log(probeName + "Ship Id: " + Ship.ShipId + " probe value: " + instrumentedDigitalWire.SignalValue);
    }
}