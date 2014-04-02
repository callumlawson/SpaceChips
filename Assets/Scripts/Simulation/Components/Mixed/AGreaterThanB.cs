using Assets.Scripts.Simulation.Components;
using Assets.Scripts.Simulation.Components.Wires;
using Assets.Scripts.Simulation.State;

internal class AGreaterThanB : Component
{
    private readonly AnalogueWire aInput;
    private readonly AnalogueWire bInput;
    private readonly DigitalWire resultOutput;

    public AGreaterThanB(Ship ship, AnalogueWire aInput, AnalogueWire bInput,
        DigitalWire resultOutput) : base()
    {
        this.resultOutput = resultOutput;
        this.bInput = bInput;
        this.aInput = aInput;
    }

    public override void OnClockEdge()
    {
        resultOutput.SignalValue = aInput.SignalValue > bInput.SignalValue;
    }
}