using UnityEngine;

internal class AnalogueProbe : Component
{
    private readonly AnalogueWire instrumentedDigitalWire;
    private readonly string probeName;

    public AnalogueProbe(Simulation simulation, Ship ship, World world, string probeName, AnalogueWire instrumentedDigitalWire) : base(simulation, ship, world)
    {
        this.instrumentedDigitalWire = instrumentedDigitalWire;
        this.probeName = probeName;
    }

    public override void OnClockEdge()
    {
        Debug.Log(probeName + "Ship Id: " + Ship.ShipId + " probe value: " + instrumentedDigitalWire.SignalValue);
    }
}
