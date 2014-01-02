using UnityEngine;

internal class ShipController
{
    private Ship ship;
    private GameObject shipView;

    private readonly float positionX;
    private readonly float positionY;
    private readonly ShipChip shipChip;
    private readonly World world;
    private readonly EngineEvents engineEvents;

    public ShipController(EngineEvents engineEvents, World world, ShipChip shipChip, float positionX, float positionY)
    {
        this.engineEvents = engineEvents;
        this.positionY = positionY;
        this.positionX = positionX;
        this.shipChip = shipChip;
        this.world = world;

        engineEvents.OnStart += OnStart;
        engineEvents.OnUpdate += OnUpdate;
        engineEvents.OnGameEnd += OnGameEnd;
    }

    private void OnStart()
    {
        CreateLogicalShip();
        CreateShipView();
    }

    private void CreateLogicalShip()
    {
        ship = new Ship(world, shipChip, positionX, positionY, rotationInDegrees: 0.0f);
        world.AddShip(ship);
    }

    private void CreateShipView()
    {
        shipView = Object.Instantiate(Resources.Load<GameObject>(ResourcePaths.ShipResourcePath)) as GameObject;
    }

    private void OnUpdate()
    {
        UpdateShipView();
        CheckShipState();
    }

    private void UpdateShipView()
    {
        shipView.transform.position = new Vector3(ship.X, ship.Y);
        shipView.transform.rotation = Quaternion.Euler(0.0f, 0.0f, ship.RotationInDegrees);
    }

    private void CheckShipState()
    {
        if (!ship.IsAlive)
        {
           DestroyShip();
        }
    }

    private void OnGameEnd()
    {
        DestroyShip();
    }

    private void DestroyShip()
    {
        Object.Destroy(shipView);
        ship.Kill();

        engineEvents.OnStart -= OnStart;
        engineEvents.OnUpdate -= OnUpdate;
        engineEvents.OnGameEnd -= OnGameEnd;
    }
}