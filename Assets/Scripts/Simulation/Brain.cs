using System.Collections.Generic;
using Assets.Scripts.Simulation.Components.Wires;
using Component = Assets.Scripts.Simulation.Components.Component;

namespace Assets.Scripts.Simulation
{
    public class Brain
    {
        private List<Component> components = new List<Component>();
        private List<IWire> wires = new List<IWire>();

        public List<Component> Components
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