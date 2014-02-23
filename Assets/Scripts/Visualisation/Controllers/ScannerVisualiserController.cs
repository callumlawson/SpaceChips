using Assets.Scripts.Simulation.GameState;
using Assets.Scripts.Visualisation.Visualisers;
using UnityEngine;

namespace Assets.Scripts.Visualisation.Controllers
{
    internal class ScannerVisualiserController : VisualiserController
    {
        private readonly Ship ship;
        private ScannerVisualiser scannerVisualiser;

        public ScannerVisualiserController(EngineEvents engineEvents, Ship ship, BasicScanner scanner, string scannerComponent) : base(engineEvents, scanner, scannerComponent)
        {
            this.ship = ship;

            InitaliseVisualiser();
        }

        protected void InitaliseVisualiser()
        {
            scannerVisualiser = ComponentGameObject.AddComponent<ScannerVisualiser>();
        }

        protected override void OnUpdate()
        {
            scannerVisualiser.SetPosition(new Vector2(ship.PositionX, ship.PositionY));
        }
    }
}