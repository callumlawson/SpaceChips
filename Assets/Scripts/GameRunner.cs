using System;
using UnityEngine;

internal class GameRunner : MonoBehaviour
{
    private EngineEvents engineEvents;
    private World world;

    private void Start()
    {
        engineEvents = gameObject.AddComponent<EngineEvents>();

        SetupWorld();
    }

    private void SetupWorld()
    {
        world = new World();
        AddShip(new BasicChip(), 1, 2);
        AddShip(new PassiveScannerChip(), 2, 1);
    }

    private void AddShip(ShipChip shipChip, float positionX, float positionY)
    {
        world.AddShip(new Ship(engineEvents, world, shipChip, positionX, positionY));
    }
}