using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Simulation.GameState;
using UnityEngine;

namespace Assets.Scripts.Simulation
{
    class GameRunner : MonoBehaviour
    {
        public World World;
        public GameObject Ship;

        private List<GameObject> ShipGameObjects = new List<GameObject>(); 

        void Start()
        {
            World = new World();
            AddShip();
        }

        private void AddShip()
        {
            //Oh the horror....
            var ship = new Ship(World) { PositionX = 2, PositionY = 3 };
            World.Ships.Add(ship);
            ShipGameObjects.Add(Instantiate(Ship) as GameObject);
        }

        void Update()
        {
            Render();
        }

        private void Render()
        {
            int index = 0;
            foreach (Ship ship in World.Ships)
            {
                ShipGameObjects.ElementAt(0).transform.position = new Vector3(ship.PositionX, ship.PositionY);
                index++;
            }
        }

        void OnDestroy()
        {
            foreach (Ship ship in World.Ships)
            {
                ship.Kill();
            }
        }
    }
}
