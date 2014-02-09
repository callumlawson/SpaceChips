internal class DigitalBuffer : Component
{
    private readonly DigitalWire bufferInput;
    private readonly DigitalWire bufferOutput;

    public DigitalBuffer(EngineEvents engineEvents, Simulation simulation, Ship ship, World world, DigitalWire bufferInput, DigitalWire bufferOutput)
        : base(simulation)
    {
        this.bufferOutput = bufferOutput;
        this.bufferInput = bufferInput;
    }

    public override void OnClockEdge()
    {
        bufferOutput.SignalValue = bufferInput.SignalValue;
    }
}