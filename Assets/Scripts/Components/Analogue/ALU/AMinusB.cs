using Assets.Scripts.Simulation.Components;
using Assets.Scripts.Simulation.Components.Wires;
using Assets.Scripts.Simulation.State;

internal class AMinusB : Chip
{
    private readonly AnalogueWire aInput;
    private readonly AnalogueWire bInput;
    private readonly float constantValue;
    private readonly AnalogueWire resultOutput;

    public AMinusB(Ship ship, AnalogueWire aInput, AnalogueWire bInput, AnalogueWire resultOutput)
    {
        this.resultOutput = resultOutput;
        this.bInput = bInput;
        this.aInput = aInput;
    }

    public override void OnClockEdge()
    {
        resultOutput.SignalValue = aInput.SignalValue - bInput.SignalValue;
    }
}