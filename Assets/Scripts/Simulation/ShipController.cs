using UnityEngine;

internal class ShipController
{
    private readonly Ship ship;
    private GameObject shipView;
    private const float InitalRotation = 0.0f;

    public ShipController(EngineEvents engineEvents, World world, ShipChip shipChip, float positionX, float positionY)
    {
        ship = new Ship(world, shipChip, positionX, positionY, InitalRotation);
        world.AddShip(ship);
        ship.StartSimulation();

        engineEvents.OnStart += OnStart;
        engineEvents.OnUpdate += OnUpdate;
        engineEvents.OnGameEnd += OnGameEnd;
    }

    private void OnStart()
    {
        shipView = Object.Instantiate(Resources.Load<GameObject>(ResourcePaths.ShipResourcePath)) as GameObject;
    }

    private void OnUpdate()
    {
        shipView.transform.position = new Vector3(ship.X, ship.Y);
        shipView.transform.rotation = Quaternion.Euler(0.0f, 0.0f, ship.RotationInDegrees);
    }

    private void OnGameEnd()
    {
        ship.StopSimulation();
    }
}