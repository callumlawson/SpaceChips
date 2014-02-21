using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class Ship
{
    public float PositionX;
    public float PositionY;
    public float RotationInDegrees;
    public int Team;
    public int InstanceId;

    public event Action OnShipDestroyed;

    private const float CollisionDistance = 0.6f;
    private readonly EngineEvents engineEvents;
    private GameObject shipView;
    private readonly Simulation simulation;
    private readonly World world;

    //Ship(Brain world view team position)
    //Brain is just box for components no ref to world ship or anything
    //Remove ship view from here and use same pattern as module
    public Ship(Simulation simulation, EngineEvents engineEvents, World world, GameObject shipView, ShipChip shipChip, int team, float positionX, float positionY)
    {
        this.engineEvents = engineEvents;
        this.world = world;
        this.shipView = shipView;
        
        PositionX = positionX;
        PositionY = positionY;
        Team = team; 

        engineEvents.OnStart += OnStart;
        engineEvents.OnUpdate += OnUpdate;
        engineEvents.OnGameEnd += Destroy;

        world.AddShip(this);
        this.simulation = simulation;
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
        world.RemoveShip(this);
        Object.Destroy(shipView);

        engineEvents.OnStart -= OnStart;
        engineEvents.OnUpdate -= OnUpdate;
        engineEvents.OnGameEnd -= Destroy;
    }

    private void OnStart()
    {
        if (shipView != null) InstanceId = shipView.GetInstanceID();
    }

    private void OnUpdate()
    {
        UpdateShipView();
        CheckForCollision();
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