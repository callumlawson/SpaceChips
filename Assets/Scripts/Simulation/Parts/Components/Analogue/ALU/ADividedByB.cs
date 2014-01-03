internal class ADividedByB : Component
{
    private readonly float constantValue;
    private readonly AnalogueWire aInput;
    private readonly AnalogueWire bInput;
    private readonly AnalogueWire resultOutput;

    public ADividedByB(EngineEvents engineEvents, Simulation simulation, Ship ship, World world, AnalogueWire aInput, AnalogueWire bInput, AnalogueWire resultOutput)
        : base(engineEvents, simulation, ship, world)
    {
        this.resultOutput = resultOutput;
        this.bInput = bInput;
        this.aInput = aInput;
    }

    public override void OnClockEdge()
    {
        //todo - consider NaN/Infinity treatment.
        resultOutput.SignalValue = aInput.SignalValue/bInput.SignalValue;
    }
}