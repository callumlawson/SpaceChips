using System.Collections.Generic;
using System.Linq;
using UnityEngine;
class GameRunner : MonoBehaviour
{
    private readonly List<GameObject> shipGameObjects = new List<GameObject>();
    public GameObject Ship;

    private World world;
    private EngineEvents engineEvents; 

    private void Start()
    {
        engineEvents = gameObject.AddComponent<EngineEvents>();
        world = new World();

        SetupWorld();
    }

    private void SetupWorld()
    {
        AddShip();
    }

    private void AddShip()
    {
        shipGameObjects.Add(global::Ship.Create());
//        var ship = new ShipModel(World) {PositionX = 2, PositionY = 3};
//        World.Ships.Add(ship);
//        shipGameObjects.Add(Instantiate(ShipModel) as GameObject);
    }
//
//    private void Render()
//    {
//        int index = 0;
//        foreach (ShipModel ship in world.Ships)
//        {
//            shipGameObjects.ElementAt(0).transform.position = new Vector3(ship.PositionX, ship.PositionY);
//            index++;
//        }
//    }

    private void OnDestroy()
    {
        foreach (ShipModel ship in world.Ships)
        {
            ship.Kill();
        }
    }
}