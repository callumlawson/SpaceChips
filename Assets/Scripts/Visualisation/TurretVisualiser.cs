using UnityEngine;

internal class TurretVisualiser : MonoBehaviour
{
    public float RotationInDegrees;

    void Update()
    {
        gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, RotationInDegrees);
    }
}