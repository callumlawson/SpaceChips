internal class Nor : Component
{
    private readonly DigitalWire aInput;
    private readonly DigitalWire bInput;
    private readonly DigitalWire resultOutput;

    public Nor(Simulation simulation, Ship ship, World world, DigitalWire aInput, DigitalWire bInput, DigitalWire resultOutput)
        : base(simulation)
    {
        this.resultOutput = resultOutput;
        this.bInput = bInput;
        this.aInput = aInput;
    }

    public override void OnClockEdge()
    {
        resultOutput.SignalValue = !(aInput.SignalValue || bInput.SignalValue);
    }
}