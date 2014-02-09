using UnityEngine;

namespace Assets.Scripts.Visualisation
{
    public class TurretVisualiserController
    {
        private readonly BasicTurret logicalTurret;
        private readonly Ship ship;
        private GameObject turretModel;
        private TurretVisualiser turretVisualiser;
        private readonly string turretComponent;

        public TurretVisualiserController(EngineEvents engineEvents, Simulation simulation, Ship ship, BasicTurret turret, string turretComponent)
        {
            this.turretComponent = turretComponent;
            logicalTurret = turret;
            this.ship = ship;

            SetupTurretModel();

            engineEvents.OnUpdate += UpdateTurretModel;
        }

        private void UpdateTurretModel()
        {
            turretVisualiser.TurretPosition = new Vector2(ship.PositionX, ship.PositionY);
            turretVisualiser.TurretDirection = logicalTurret.TurretDirection;
        }

        //TODO - This needs a rethink... to easy to fire before direction is updated.
        private void FireLazer()
        {
            turretVisualiser.TurretPosition = new Vector2(ship.PositionX, ship.PositionY);
            turretVisualiser.TurretDirection = logicalTurret.TurretDirection;
            turretVisualiser.VisualiseLazerFiring();
        }

        private void SetupTurretModel()
        {
            turretModel = Object.Instantiate(Resources.Load<GameObject>(turretComponent)) as GameObject;
            if (turretModel != null)
            {
                turretVisualiser = turretModel.AddComponent<TurretVisualiser>();
            }
            else
            {
                Debug.LogError("Unable to instantiate: " + turretComponent + ", is the resource path correct?");
            }

            logicalTurret.VisualiseLazerFiring += FireLazer;
        }
    }
}