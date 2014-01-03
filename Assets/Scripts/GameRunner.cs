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
        CreateShip(new BasicChip(), 4, 5);
        CreateShip(new CowardChip(), -1, -3);
        CreateShip(new OrbitChip(), 0, 0);
    }

    private void CreateShip(ShipChip shipChip, float positionX, float positionY)
    {
        new Ship(engineEvents, world, shipChip, 0, positionX, positionY);
    }
}