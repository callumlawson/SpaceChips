using Assets.Scripts.Simulation;
using Assets.Scripts.Simulation.Components;
using Assets.Scripts.Simulation.Components.Wires;
using Assets.Scripts.Simulation.GameState;

internal class AnalogueConstant : Component
{
    private readonly float constantValue;
    private readonly AnalogueWire constantValueOuput;

    public AnalogueConstant(Brain brain, Ship ship, World world, float constantValue, AnalogueWire constantValueOuput) : base()
    {
        this.constantValueOuput = constantValueOuput;
        this.constantValue = constantValue;
    }

    public override void OnClockEdge()
    {
        constantValueOuput.SignalValue = constantValue;
    }
}