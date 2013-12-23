using System;

namespace Assets.Scripts.Simulation.Parts.Components.Digital
{
    internal class And : Component
    {
        private DigitalWire aInput;
        private DigitalWire bInput;
        private DigitalWire resultOutput;

        public And(global::Simulation simulation, Ship ship, World world, DigitalWire aInput, DigitalWire bInput, DigitalWire resultOutput) : base(simulation, ship, world)
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