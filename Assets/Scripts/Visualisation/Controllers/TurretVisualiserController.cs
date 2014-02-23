using Assets.Scripts.Simulation.GameState;
using UnityEngine;

namespace Assets.Scripts.Visualisation.Controllers
{
    public class TurretVisualiserController : VisualiserController
    {
        private readonly BasicTurret turret;
        private readonly Ship ship;
        private TurretVisualiser turretVisualiser;

        public TurretVisualiserController(EngineEvents engineEvents, Ship ship, BasicTurret turret, string turretComponent) : base(engineEvents, turret, turretComponent)
        {
            this.ship = ship;
            this.turret = turret;

            InitaliseVisualiser();
        }

        //TODO - This needs a rethink... to easy to fire before direction is updated.
        private void FireLazer()
        {
            OnUpdate();
            turretVisualiser.VisualiseLazerFiring();
        }

        protected void InitaliseVisualiser()
        {
            turretVisualiser = ComponentGameObject.AddComponent<TurretVisualiser>();
            turret.LazerFired += FireLazer;
        }

        protected override void OnUpdate()
        {
            turretVisualiser.TurretPosition = new Vector2(ship.PositionX, ship.PositionY);
            turretVisualiser.TurretDirection = turret.TurretDirection;
        }
    }
}