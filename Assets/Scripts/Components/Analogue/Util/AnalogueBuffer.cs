using Assets.Scripts.Simulation.Components;
using Assets.Scripts.Simulation.Components.Wires;
using Assets.Scripts.Simulation.State;

internal class AnalogueBuffer : Chip
{
    private readonly AnalogueWire bufferInput;
    private readonly AnalogueWire bufferOutput;

    public AnalogueBuffer(Ship ship, AnalogueWire bufferInput, AnalogueWire bufferOutput)
    {
        this.bufferInput = bufferInput;
        this.bufferOutput = bufferOutput;
    }

    public override void OnClockEdge()
    {
        bufferOutput.SignalValue = bufferInput.SignalValue;
    }
}