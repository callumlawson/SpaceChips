using Assets.Scripts.Simulation.Components.Wires;
using Assets.Scripts.Simulation.State;

namespace Assets.Scripts.Simulation.Components.Digital.LogicGates
{
    internal class And : Chip
    {
        public readonly DigitalWire aInput;
        public readonly DigitalWire bInput;
        public readonly DigitalWire resultOutput;

        public And(Ship ship, DigitalWire aInput, DigitalWire bInput, DigitalWire resultOutput)
        {
            this.resultOutput = resultOutput;
            this.bInput = bInput;
            this.aInput = aInput;
        }

        public override void OnClockEdge()
        {
            resultOutput.SignalValue = aInput.SignalValue && bInput.SignalValue;
        }
    }
}