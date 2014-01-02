using UnityEngine;

internal class GameRunner : MonoBehaviour
{
    private readonly World world = new World();
    private EngineEvents engineEvents;

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
        CreateShip(new BasicChip(), -1, -3);
    }

    private void CreateShip(ShipChip shipChip, float positionX, float positionY)
    {
        new Ship(engineEvents, world, shipChip, positionX, positionY);
    }
}