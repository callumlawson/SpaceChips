using UnityEngine;

internal class Ship
{
    private readonly ShipModel shipModel;
    private GameObject shipView;

    public Ship(EngineEvents engineEvents, World world, ShipChip shipChip, float positionX, float positionY)
    {
        shipModel = new ShipModel(world, shipChip, positionX, positionY);
        shipModel.StartSimulation();

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
        shipView.transform.position = new Vector3(shipModel.PositionX, shipModel.PositionY);
    }

    private void OnGameEnd()
    {
        shipModel.StopSimulation();
    }
}