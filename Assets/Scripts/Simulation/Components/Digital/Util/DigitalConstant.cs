using Assets.Scripts.Simulation;
using Assets.Scripts.Simulation.Components;
using Assets.Scripts.Simulation.Components.Wires;
using Assets.Scripts.Simulation.GameState;

internal class DigitalConstant : Component
{
    private readonly bool constantValue;
    private readonly DigitalWire constantValueOuput;

    public DigitalConstant(EngineEvents engineEvents, Brain brain, Ship ship, World world, bool constantValue, DigitalWire constantValueOuput)
        : base()
    {
        this.constantValueOuput = constantValueOuput;
        this.constantValue = constantValue;
    }

    public override void OnClockEdge()
    {
        constantValueOuput.SignalValue = constantValue;
    }
}