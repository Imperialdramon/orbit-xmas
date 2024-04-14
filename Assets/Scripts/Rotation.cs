using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float rotationSpeed = 20f;

    void Update()
    {
        RotacionPlaneta();
    }
    void RotacionPlaneta()
    {
        float rotation = rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.forward, rotation);
    }
}
