using UnityEngine;

internal class AnalogueProbe : Component
{
    private readonly AnalogueWire instrumentedAnalogueWire;
    private readonly string probeName;
    private readonly Ship ship;

    public AnalogueProbe(EngineEvents engineEvents, Simulation simulation, Ship ship, World world, string probeName, AnalogueWire instrumentedAnalogueWire) : base(simulation)
    {
        this.ship = ship;
        this.instrumentedAnalogueWire = instrumentedAnalogueWire;
        this.probeName = probeName;
    }

    public override void OnClockEdge()
    {
        Debug.Log(probeName + "Ship Id: " + ship.InstanceId + " probe value: " + instrumentedAnalogueWire.SignalValue);
    }
}
