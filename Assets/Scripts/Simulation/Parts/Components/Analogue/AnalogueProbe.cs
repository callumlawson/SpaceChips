using UnityEngine;

internal class AnalogueProbe : Component
{
    private readonly AnalogueWire instrumentedAnalogueWire;
    private readonly string probeName;

    public AnalogueProbe(Simulation simulation, Ship ship, World world, string probeName, AnalogueWire instrumentedAnalogueWire) : base(simulation, ship, world)
    {
        this.instrumentedAnalogueWire = instrumentedAnalogueWire;
        this.probeName = probeName;
    }

    public override void OnClockEdge()
    {
        Debug.Log(probeName + "Ship Id: " + Ship.ShipId + " probe value: " + instrumentedAnalogueWire.SignalValue);
    }
}
