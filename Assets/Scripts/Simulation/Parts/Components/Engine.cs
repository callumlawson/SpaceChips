using System.Diagnostics;
using Assets.Scripts.Simulation.GameState;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Assets.Scripts.Simulation.Parts.Components
{
    class Engine : Component
    {
        private Ship ship;
        private Wire deltaXInput;
        private Wire deltaYInput;

        public Engine(Simulation simulation, Ship ship, Wire deltaXInput, Wire deltaYInput) : base(simulation)
        {
            this.deltaYInput = deltaYInput;
            this.deltaXInput = deltaXInput;
            this.ship = ship;
        }

        public override void OnClockEdge()
        {
            Debug.Log("position updated");
            ship.PositionX += deltaXInput.SignalValue;
            ship.PositionY += deltaYInput.SignalValue;
        }
    }
}
