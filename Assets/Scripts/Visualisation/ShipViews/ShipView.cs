using System;
using Assets.Scripts.Simulation.GameState;
using UnityEngine;

namespace Assets.Scripts.Visualisation.NewStyle
{
    class ShipView : MonoBehaviour, IShipView
    {
        private Ship ship;

        public void Initialize(Ship ship)
        {
            this.ship = ship;
        }

        void Update()
        {
            transform.position = new Vector3(ship.PositionX, ship.PositionY);
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, ship.RotationInDegrees);
        }
    }
}
