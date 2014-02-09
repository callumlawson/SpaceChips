internal class AnalogueConstant : Component
{
    private readonly float constantValue;
    private readonly AnalogueWire constantValueOuput;

    public AnalogueConstant(EngineEvents engineEvents, Simulation simulation, Ship ship, World world, float constantValue, AnalogueWire constantValueOuput) : base(simulation)
    {
        this.constantValueOuput = constantValueOuput;
        this.constantValue = constantValue;
    }

    public override void OnClockEdge()
    {
        constantValueOuput.SignalValue = constantValue;
    }
}