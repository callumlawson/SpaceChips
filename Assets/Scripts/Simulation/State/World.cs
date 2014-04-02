using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Visualisation.NewStyle;
using UnityEngine;

namespace Assets.Scripts.Simulation.State
{
    public class World
    {
        private readonly List<Ship> ships = new List<Ship>();

        public void AddShip(Ship ship)
        {
            ships.Add(ship);
        }

        public void RemoveShip(Ship ship)
        {
            ships.Remove(ship);
        }

        public List<Ship> GetShips()
        {
            return ships;
        }

        public Ship GetShipByShipId(int shipId)
        {
            return ships.FirstOrDefault(ship => ship.ShipId == shipId);
        }

        public int? GameObjectToShipId(GameObject gameObject)
        {
            var shipView = gameObject.GetComponent<ShipView>();
            return shipView.GetShipId();
        }

        public Ship GameObjectToShip(GameObject gameObject)
        {
            var shipId = GameObjectToShipId(gameObject);
            return shipId.HasValue ? GetShipByShipId(shipId.Value) : null;
        }
    }
}