using Assets.Scripts.Simulation.Components;
using Assets.Scripts.Simulation.Components.Wires;
using Assets.Scripts.Simulation.State;

internal class AnalogueConstant : Chip
{
    private readonly float constantValue;
    private readonly AnalogueWire constantValueOuput;

    public AnalogueConstant(Ship ship, float constantValue, AnalogueWire constantValueOuput)
    {
        this.constantValueOuput = constantValueOuput;
        this.constantValue = constantValue;
    }

    public override void OnClockEdge()
    {
        constantValueOuput.SignalValue = constantValue;
    }
}