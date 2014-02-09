internal class AnalogueConstant : Component
{
    private readonly float constantValue;
    private readonly AnalogueWire constantValueOuput;

    public AnalogueConstant(Simulation simulation, Ship ship, World world, float constantValue, AnalogueWire constantValueOuput) : base(simulation, ship)
    {
        this.constantValueOuput = constantValueOuput;
        this.constantValue = constantValue;
    }

    public override void OnClockEdge()
    {
        constantValueOuput.SignalValue = constantValue;
    }
}