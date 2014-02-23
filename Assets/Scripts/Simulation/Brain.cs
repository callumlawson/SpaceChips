using System.Collections.Generic;
using Assets.Scripts.Simulation.Components;
using Assets.Scripts.Simulation.Components.Wires;

//Dis be prototype and evil!
//ShipBrain - this contains the chips   Add chip  Kill the brain
namespace Assets.Scripts.Simulation
{
    public class Brain
    {
        private readonly List<Component> components = new List<Component>();
        private readonly List<IWire> wires = new List<IWire>();

        public void AddComponent(Component component)
        {
            components.Add(component);
        }

        public void AddWire(IWire wire)
        {
            wires.Add(wire);
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