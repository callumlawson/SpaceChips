internal class Not : Component
{
    private readonly DigitalWire signalInput;
    private readonly DigitalWire negatedOutput;

    public Not(EngineEvents engineEvents, Simulation simulation, Ship ship, World world, DigitalWire signalInput, DigitalWire negatedOutput)
        : base(simulation, ship)
    {
        this.negatedOutput = negatedOutput;
        this.signalInput = signalInput;
    }

    public override void OnClockEdge()
    {
        negatedOutput.SignalValue = !signalInput.SignalValue;
    }
}