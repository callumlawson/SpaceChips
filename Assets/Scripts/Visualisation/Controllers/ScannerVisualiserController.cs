using Assets.Scripts.Visualisation.Visualisers;
using UnityEngine;

namespace Assets.Scripts.Visualisation.Controllers
{
    //TODO - extract event handlers into abstract class.
    internal class ScannerVisualiserController
    {
        private readonly string scannerComponent;
        private ScannerVisualiser scannerVisualiser;
        private readonly Ship ship;
        private GameObject scannerModel;
        private readonly EngineEvents engineEvents;
        private readonly BasicScanner scanner;

        public ScannerVisualiserController(EngineEvents engineEvents, Ship ship, BasicScanner scanner, string scannerComponent)
        {
            this.scanner = scanner;
            this.engineEvents = engineEvents;
            this.ship = ship;
            this.scannerComponent = scannerComponent;

            SetupScannerModel();

            engineEvents.OnUpdate += UpdateScannerPosition;

            scanner.OnComponentDestroyed += Destroy;
        }

        private void UpdateScannerPosition()
        {
            scannerVisualiser.SetPosition(new Vector2(ship.PositionX, ship.PositionY));
        }

        private void SetupScannerModel()
        {
            scannerModel = Object.Instantiate(Resources.Load<GameObject>(scannerComponent)) as GameObject;
            if (scannerModel != null)
            {
                scannerVisualiser = scannerModel.AddComponent<ScannerVisualiser>();
            }
            else
            {
                Debug.LogError("Unable to instantiate: " + scannerComponent + ", is the resource path correct?");
            }
        }

        private void Destroy()
        {
            engineEvents.OnUpdate -= UpdateScannerPosition;
            Object.Destroy(scannerModel);
            scanner.OnComponentDestroyed -= Destroy;
        }
    }
}