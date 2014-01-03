using UnityEngine;

internal class TurretVisualiser : MonoBehaviour
{
    public float RotationInDegrees;

    private LineRenderer lazer;

    void Start()
    {
        lazer = GetComponent<LineRenderer>();
        if (lazer == null)
        {
           Debug.LogError("Turret visualiser expected line renderer but found none.");
        }
    }

    void Update()
    {
        gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, RotationInDegrees);
    }

    public void FireLazer(Vector2 origin, Vector2 destination)
    {
        lazer.SetPosition(0, new Vector3(origin.x, origin.y));
        lazer.SetPosition(1, new Vector3(destination.x, destination.y));
    }
}