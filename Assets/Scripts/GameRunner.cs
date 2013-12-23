using System;
using UnityEngine;

internal class GameRunner : MonoBehaviour
{
    private EngineEvents engineEvents;
    private readonly World world = new World();

    private void Start()
    {
        SetupSingletons();
        SetupWorld();
    }

    private void SetupSingletons()
    {
        engineEvents = gameObject.AddComponent<EngineEvents>();
    }

    private void SetupWorld()
    {
        CreateShip(new BasicChip(), 2, 4);
//        CreateShip(new BasicChip(), -1, -2);
//        CreateShip(new BasicChip(), -3, -1);
        CreateShip(new BasicChip(), -1, -3);
//        CreateShip(new PassiveChip(), 1, 3);
//        CreateShip(new BasicChip(), -2, -5);
   
    }

    private void CreateShip(ShipChip shipChip, float positionX, float positionY)
    {
        new ShipController(engineEvents, world, shipChip, positionX, positionY);
    }
}