internal class DigitalConstant : Component
{
    private readonly bool constantValue;
    private readonly DigitalWire constantValueOuput;

    public DigitalConstant(EngineEvents engineEvents, Simulation simulation, Ship ship, World world, bool constantValue, DigitalWire constantValueOuput)
        : base(engineEvents, simulation, ship, world)
    {
        this.constantValueOuput = constantValueOuput;
        this.constantValue = constantValue;
    }

    public override void OnClockEdge()
    {
        constantValueOuput.SignalValue = constantValue;
    }
}