using System.Linq;

namespace Assets.Scripts.Simulation.GameState
{
    public class Ship
    {
        public float PositionX;
        public float PositionY;
        public float RotationInDegrees;
        public int Team;
        //Asigned by ships builder?
        public int ShipId;

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
            engineEvents.OnGameEnd += Destroy;

            world.AddShip(this);
        }

        public void Destroy()
        {
            brain.Destroy();

            world.RemoveShip(this);

            engineEvents.OnUpdate -= OnUpdate;
            engineEvents.OnGameEnd -= Destroy;
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

        private void OnUpdate()
        {
            brain.Tick();
            CheckForCollision();
        }

        private void CheckForCollision()
        {
            var nearestShip = world.GetNearestShip(this);
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