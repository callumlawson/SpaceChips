internal class AnalogueBuffer : Component
{
    private readonly AnalogueWire bufferInput;
    private readonly AnalogueWire bufferOutput;

    public AnalogueBuffer(Simulation simulation, Ship ship, World world, AnalogueWire bufferInput, AnalogueWire bufferOutput)
        : base(simulation, ship, world)
    {
        this.bufferInput = bufferInput;
        this.bufferOutput = bufferOutput;
    }

    public override void OnClockEdge()
    {
        bufferOutput.SignalValue = bufferInput.SignalValue;
    }
}