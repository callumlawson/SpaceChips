using Assets.Scripts.Simulation;
using Assets.Scripts.Simulation.Components;
using Assets.Scripts.Simulation.Components.Wires;
using Assets.Scripts.Simulation.GameState;

internal class ADividedByB : Component
{
    private readonly float constantValue;
    private readonly AnalogueWire aInput;
    private readonly AnalogueWire bInput;
    private readonly AnalogueWire resultOutput;

    public ADividedByB(Brain brain, Ship ship, World world, AnalogueWire aInput, AnalogueWire bInput, AnalogueWire resultOutput)
        : base()
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