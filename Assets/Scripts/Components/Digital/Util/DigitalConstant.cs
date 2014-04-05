using Assets.Scripts.Simulation.Components;
using Assets.Scripts.Simulation.Components.Wires;
using Assets.Scripts.Simulation.State;

internal class DigitalConstant : Chip
{
    private readonly bool constantValue;
    private readonly DigitalWire constantValueOuput;

    public DigitalConstant(Ship ship, bool constantValue, DigitalWire constantValueOuput)
    {
        this.constantValueOuput = constantValueOuput;
        this.constantValue = constantValue;
    }

    public override void OnClockEdge()
    {
        constantValueOuput.SignalValue = constantValue;
    }
}