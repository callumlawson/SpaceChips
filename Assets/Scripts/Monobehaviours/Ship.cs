using UnityEngine;
class Ship : MonoBehaviour
{
    private ShipModel shipModel;
    private GameObject shipView;
    void Initialize(World world)
    {
        shipModel = new ShipModel(world);    
    }

    void Start()
    {
        var shipView = Instantiate(Resources.Load<GameObject>(ResourcePaths.ShipResourcePath)) as GameObject;
    }

    void Update()
    {
        gameObject.transform.position = new Vector3(shipModel.PositionX, shipModel.PositionY);
    }
}