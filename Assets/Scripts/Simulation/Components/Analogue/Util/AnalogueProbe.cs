using UnityEngine;

internal class AnalogueProbe : Component
{
    private readonly AnalogueWire instrumentedAnalogueWire;
    private readonly string probeName;

    public AnalogueProbe(EngineEvents engineEvents, Simulation simulation, Ship ship, World world, string probeName, AnalogueWire instrumentedAnalogueWire) : base(engineEvents, simulation, ship, world)
    {
        this.instrumentedAnalogueWire = instrumentedAnalogueWire;
        this.probeName = probeName;
    }

    public override void OnClockEdge()
    {
        Debug.Log(probeName + "Ship Id: " + Ship.ShipId + " probe value: " + instrumentedAnalogueWire.SignalValue);
    }
}
