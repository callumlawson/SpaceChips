internal class Not : Component
{
    private DigitalWire signalInput;
    private DigitalWire negatedOutput;

    public Not(EngineEvents engineEvents, Simulation simulation, Ship ship, World world, DigitalWire signalInput, DigitalWire negatedOutput)
        : base(engineEvents, simulation, ship, world)
    {
        this.negatedOutput = negatedOutput;
        this.signalInput = signalInput;
    }

    public override void OnClockEdge()
    {
        negatedOutput.SignalValue = !signalInput.SignalValue;
    }
}