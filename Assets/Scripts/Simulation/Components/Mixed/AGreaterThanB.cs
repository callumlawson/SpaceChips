internal class AGreaterThanB : Component
{
    private readonly AnalogueWire aInput;
    private readonly AnalogueWire bInput;
    private readonly DigitalWire resultOutput;

    public AGreaterThanB(EngineEvents engineEvents, Simulation simulation, Ship ship, World world, AnalogueWire aInput, AnalogueWire bInput,
        DigitalWire resultOutput) : base(simulation)
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