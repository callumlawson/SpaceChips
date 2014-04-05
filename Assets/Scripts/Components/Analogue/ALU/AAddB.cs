using Assets.Scripts.Simulation.Components;
using Assets.Scripts.Simulation.Components.Wires;
using Assets.Scripts.Simulation.State;

namespace Assets.Scripts.Components.Analogue.ALU
{
    internal class AAddB : Chip
    {
        private readonly AnalogueWire aInput;
        private readonly AnalogueWire bInput;
        private readonly float constantValue;
        private readonly AnalogueWire resultOutput;

        public AAddB(Ship ship, AnalogueWire aInput, AnalogueWire bInput, AnalogueWire resultOutput)
        {
            this.resultOutput = resultOutput;
            this.bInput = bInput;
            this.aInput = aInput;
        }

        public override void OnClockEdge()
        {
            resultOutput.SignalValue = aInput.SignalValue + bInput.SignalValue;
        }
    }
}