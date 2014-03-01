using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Simulation.GameState
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
    }
}