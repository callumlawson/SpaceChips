internal class ASuppressB : Component
{
	private readonly DigitalWire aInput;
	private readonly AnalogueWire bInput;
	private readonly AnalogueWire resultOutput;
	
	public ASuppressB(Simulation simulation, Ship ship, World world, DigitalWire aInput, AnalogueWire bInput, AnalogueWire resultOutput) 
        : base(simulation, ship)
	{
		this.resultOutput = resultOutput;
		this.bInput = bInput;
		this.aInput = aInput;
	}
	
	public override void OnClockEdge()
	{
		if (aInput.SignalValue) resultOutput.SignalValue = 0f;
		else resultOutput.SignalValue = bInput.SignalValue;

	}
}