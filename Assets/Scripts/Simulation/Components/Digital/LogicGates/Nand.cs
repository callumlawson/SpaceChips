using Assets.Scripts.Simulation.Components;
using Assets.Scripts.Simulation.Components.Wires;
using Assets.Scripts.Simulation.State;

internal class Nand : Component
{
    private readonly DigitalWire aInput;
    private readonly DigitalWire bInput;
    private readonly DigitalWire resultOutput;

    public Nand(Ship ship, DigitalWire aInput, DigitalWire bInput, DigitalWire resultOutput)
    {
        this.resultOutput = resultOutput;
        this.bInput = bInput;
        this.aInput = aInput;
    }

    public override void OnClockEdge()
    {
        resultOutput.SignalValue = !(aInput.SignalValue && bInput.SignalValue);
    }

    //ToJSON() {
    //
    //class: digital.AND
    //
    //
    //}

    //FromJSON
}