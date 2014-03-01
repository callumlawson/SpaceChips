using System;
using System.Linq;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Assets.Scripts.Simulation.GameState
{
    public class Ship
    {
        public float PositionX;
        public float PositionY;
        public float RotationInDegrees;
        public int Team;
        public int ShipId;
        public event Action OnShipDestroyed; 

        private readonly EngineEvents engineEvents;
        private readonly Brain brain;
        private readonly World world;

        private static int numShips;
        private const float CollisionDistance = 0.6f;


        //Ship(Brain world view team position)
        //Brain is just box for components no ref to world ship or anything

        //Remove ship view from here and use same pattern as module
        public Ship(EngineEvents engineEvents, Brain brain, World world, int shipId, int team, float positionX, float positionY)
        {
            this.engineEvents = engineEvents;
            this.brain = brain;
            this.world = world;
            ShipId = shipId;
            Team = team; 
            PositionX = positionX;
            PositionY = positionY;

            engineEvents.OnUpdate += OnUpdate;

            world.AddShip(this);
        }

        public void Destroy()
        {
            Debug.Log("Ship destroyed");

            engineEvents.OnUpdate -= OnUpdate;
            engineEvents.OnGameEnd -= Destroy;

            brain.Destroy();

            world.RemoveShip(this);

            if (OnShipDestroyed != null)
            {
                OnShipDestroyed.Invoke();
            }
        }

        public Ship GetNearestShip()
        {
            return world.GetShips().Where(ship => ship.ShipId != ShipId)
                .OrderBy(ship => SpaceMath.DistanceBetweenTwoPoints(PositionX, PositionY, ship.PositionX, ship.PositionY))
                .FirstOrDefault();
        }

        public Ship GetNearestShipOnTeam()
        {
            return world.GetShips().Where(ship => ship.ShipId != ShipId)
                .OrderBy(ship => SpaceMath.DistanceBetweenTwoPoints(PositionX, PositionY, ship.PositionX, ship.PositionY))
                .FirstOrDefault(ship => ship.Team == Team);
        }

        public Ship GetNearestShipNotOnTeam()
        {
            return world.GetShips().Where(ship => ship.ShipId != ShipId)
                .OrderBy(ship => SpaceMath.DistanceBetweenTwoPoints(PositionX, PositionY, ship.PositionX, ship.PositionY))
                .FirstOrDefault(ship => ship.Team != Team);
        }

        public Ship GetShipFromShipId(int shipId)
        {
            return world.GetShipByShipId(ShipId);
        }

        public int? GameObjectToShipId(GameObject gameObject)
        {
            return world.GameObjectToShipId(gameObject);
        }

        public Ship GameObjectToShip(GameObject gameObject)
        {
            return world.GameObjectToShip(gameObject);
        }

        private void OnUpdate()
        {
            brain.Tick();
            CheckForCollision();
        }

        private void CheckForCollision()
        {
            var nearestShip = GetNearestShip();
            if (nearestShip != null)
            {
                if (SpaceMath.DistanceBetweenTwoPoints(PositionX, PositionY, nearestShip.PositionX, nearestShip.PositionY) <= CollisionDistance)
                {
                    nearestShip.Destroy();
                    Destroy();
                }
            }
        }
    }
}