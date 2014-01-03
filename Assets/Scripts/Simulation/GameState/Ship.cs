using System;
using UnityEngine;
using Object = UnityEngine.Object;

internal class Ship
{
    public float PositionX;
    public float PositionY;
    public float RotationInDegrees;
    public int Team;
    public int ShipId;
    public event Action OnShipDestroyed;

    private static int shipCount;
    private const float CollisionDistance = 0.6f;

    private readonly EngineEvents engineEvents;
    private GameObject shipView;
    private readonly Simulation simulation;
    private readonly World world;

    public Ship(EngineEvents engineEvents, World world, ShipChip shipChip, int team, float positionX, float positionY)
    {
        shipCount += 1;

        this.engineEvents = engineEvents;
        this.world = world;
        PositionX = positionX;
        PositionY = positionY;
        ShipId = shipCount;
        Team = team; 

        engineEvents.OnStart += OnStart;
        engineEvents.OnUpdate += OnUpdate;
        engineEvents.OnGameEnd += Destroy;

        world.AddShip(this);
        simulation = new Simulation();
        shipChip.Setup(engineEvents, this, world, simulation);
        simulation.Start();
    }

    public void Destroy()
    {
        if (OnShipDestroyed != null)
        {
            OnShipDestroyed.Invoke();
        }
        
        simulation.Stop();
        Object.Destroy(shipView);

        engineEvents.OnStart -= OnStart;
        engineEvents.OnUpdate -= OnUpdate;
        engineEvents.OnGameEnd -= Destroy;
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

    private void CreateShipView()
    {
        shipView = Object.Instantiate(Resources.Load<GameObject>(ResourcePaths.ShipResourcePath)) as GameObject;
    }

    private void UpdateShipView()
    {
        shipView.transform.position = new Vector3(PositionX, PositionY);
        shipView.transform.rotation = Quaternion.Euler(0.0f, 0.0f, RotationInDegrees);
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