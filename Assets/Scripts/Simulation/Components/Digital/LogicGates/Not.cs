using Assets.Scripts.Simulation;
using Assets.Scripts.Simulation.Components;
using Assets.Scripts.Simulation.Components.Wires;
using Assets.Scripts.Simulation.GameState;

internal class Not : Component
{
    private readonly DigitalWire signalInput;
    private readonly DigitalWire negatedOutput;

    public Not(EngineEvents engineEvents, Brain brain, Ship ship, World world, DigitalWire signalInput, DigitalWire negatedOutput)
        : base()
    {
        this.negatedOutput = negatedOutput;
        this.signalInput = signalInput;
    }

    public override void OnClockEdge()
    {
        negatedOutput.SignalValue = !signalInput.SignalValue;
    }
}