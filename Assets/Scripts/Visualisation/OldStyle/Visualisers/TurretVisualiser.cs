//using UnityEngine;
//
//internal class TurretVisualiser : MonoBehaviour
//{
//    public Vector2 TurretPosition;
//    public Vector2 TurretDirection;
//
//    public void VisualiseLazerFiring()
//    {
//        VisualiseLazerFiring(TurretPosition, TurretPosition + (TurretDirection.normalized * LazerLength));
//
//        //Shudder - It'l do for now.
//        Invoke("TurnOffTheLazor", 1.0f);
//    }
//
//    private const float LazerLength = 200.0f;
//    private LineRenderer lazer;
//
//    void Start()
//    {
//        lazer = GetComponent<LineRenderer>();
//        if (lazer == null)
//        {
//            Debug.LogError("Turret visualiser expected a line renderer but did not find one.");
//        }
//    }
//
//    void Update()
//    {
//        gameObject.transform.position = TurretPosition;
//    }
//
//    private void VisualiseLazerFiring(Vector2 origin, Vector2 destination)
//    {
//        lazer.SetPosition(0, new Vector3(origin.x, origin.y));
//        lazer.SetPosition(1, new Vector3(destination.x, destination.y));
//    }
//
//    //Lulz
//    private void TurnOffTheLazor()
//    {
//        lazer.SetPosition(0, new Vector3(TurretPosition.x, TurretPosition.y, 0));
//        lazer.SetPosition(1, new Vector3(TurretPosition.x, TurretPosition.y, 0));
//    }
//}