using UnityEngine;

namespace Assets.Scripts.Simulation.Parts.Components
{
    internal class Probe : Component
    {
        private readonly Wire instrumentedWire;
        private readonly string probeName;

        public Probe(Simulation simulation, string probeName, Wire instrumentedWire): base(simulation)
        {
            this.instrumentedWire = instrumentedWire;
            this.probeName = probeName;
        }

        public override void OnClockEdge()
        {
            Debug.Log(probeName + " probe value: " + instrumentedWire.SignalValue);
        }
    }
}