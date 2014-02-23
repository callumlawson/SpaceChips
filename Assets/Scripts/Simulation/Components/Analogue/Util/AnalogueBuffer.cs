using Assets.Scripts.Simulation;
using Assets.Scripts.Simulation.Components;
using Assets.Scripts.Simulation.Components.Wires;
using Assets.Scripts.Simulation.GameState;

internal class AnalogueBuffer : Component
{
    private readonly AnalogueWire bufferInput;
    private readonly AnalogueWire bufferOutput;

    public AnalogueBuffer(Brain brain, Ship ship, World world, AnalogueWire bufferInput, AnalogueWire bufferOutput)
        : base()
    {
        this.bufferInput = bufferInput;
        this.bufferOutput = bufferOutput;
    }

    public override void OnClockEdge()
    {
        bufferOutput.SignalValue = bufferInput.SignalValue;
    }
}