using Assets.Scripts.Simulation.Components;
using Assets.Scripts.Simulation.Components.Wires;
using Assets.Scripts.Simulation.State;

internal class Not : Chip
{
    private readonly DigitalWire signalInput;
    private readonly DigitalWire negatedOutput;

    public Not(Ship ship, DigitalWire signalInput, DigitalWire negatedOutput)
    {
        this.negatedOutput = negatedOutput;
        this.signalInput = signalInput;
    }

    public override void OnClockEdge()
    {
        negatedOutput.SignalValue = !signalInput.SignalValue;
    }
}