internal class AAddB : Component
{
    private readonly float constantValue;
    private readonly AnalogueWire aInput;
    private readonly AnalogueWire bInput;
    private readonly AnalogueWire resultOutput;

    public AAddB(Simulation simulation, Ship ship, World world, AnalogueWire aInput, AnalogueWire bInput, AnalogueWire resultOutput)
        : base(simulation, ship)
    {
        this.resultOutput = resultOutput;
        this.bInput = bInput;
        this.aInput = aInput;
    }

    public override void OnClockEdge()
    {
        resultOutput.SignalValue = aInput.SignalValue + bInput.SignalValue;
    }
}