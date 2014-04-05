using System.Collections.Generic;
using Assets.Scripts.Simulation.Components;
using Assets.Scripts.Simulation.Components.Wires;

namespace Assets.Scripts.Simulation
{
    public class Brain
    {
        private List<Chip> components = new List<Chip>();
        private List<IWire> wires = new List<IWire>();

        public List<Chip> Components
        {
            set { components = value; }
        }

        public List<IWire> Wires
        {
            set { wires = value; }
        }

        public void Destroy()
        {
            components.ForEach(component => component.Destroy());
        }

        public void Tick()
        {
            components.ForEach(component => component.OnClockEdge());
            wires.ForEach(wire => wire.AfterClockEdge());
        }
    }
}