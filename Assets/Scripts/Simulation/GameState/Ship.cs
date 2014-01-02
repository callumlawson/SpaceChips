using UnityEngine;

internal class Ship
{
    public float X;
    public float Y;
    public float RotationInDegrees;
    public int ShipId;
    private static int shipCount;

    private const float CollisionDistance = 0.6f;

    private readonly EngineEvents engineEvents;
    private GameObject shipView;
    private readonly Simulation simulation;
    private readonly World world;

    public Ship(EngineEvents engineEvents, World world, ShipChip shipChip, float positionX, float positionY)
    {
        engineEvents.OnStart += OnStart;
        engineEvents.OnUpdate += OnUpdate;
        engineEvents.OnGameEnd += OnGameEnd;

        shipCount += 1;
        ShipId = shipCount;

        this.engineEvents = engineEvents;
        this.world = world;
        X = positionX;
        Y = positionY;

        world.AddShip(this);
        simulation = new Simulation();
        shipChip.Setup(this, world, simulation);
        simulation.Start();
    }

    public void Destroy()
    {
        simulation.Stop();
        Object.Destroy(shipView);

        engineEvents.OnStart -= OnStart;
        engineEvents.OnUpdate -= OnUpdate;
        engineEvents.OnGameEnd -= OnGameEnd;
    }

    private void OnStart()
    {
        CreateShipView();
    }

    private void OnUpdate()
    {
        UpdateShipView();
        CheckForCollision();
    }

    private void OnGameEnd()
    {
        Destroy();
    }

    private void CreateShipView()
    {
        shipView = Object.Instantiate(Resources.Load<GameObject>(ResourcePaths.ShipResourcePath)) as GameObject;
    }

    private void UpdateShipView()
    {
        shipView.transform.position = new Vector3(X, Y);
        shipView.transform.rotation = Quaternion.Euler(0.0f, 0.0f, RotationInDegrees);
    }

    private void CheckForCollision()
    {
        var nearestShip = world.GetNearestShip(this);
        if (nearestShip != null)
        {
            if (SpaceMath.DistanceBetweenTwoPoints(X, Y, nearestShip.X, nearestShip.Y) <= CollisionDistance)
            {
                nearestShip.Destroy();
                Destroy();
            }
        }
    }
}