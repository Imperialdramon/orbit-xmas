using UnityEngine;

public class Movement : MonoBehaviour
{
    //public float speed = 5f; // Velocidad de movimiento en unidades por segundo
    public float movementDistance = 1.5f; // Distancia de movimiento en unidades
    public float movementTime = 0.1f; // Duración del movimiento en segundos

    private float limitUp; // Límite de altura de subida
    private float limitDown; // Límite de altura de bajada

    private bool onMovement = false; // Bandera para verificar si el objeto está en movimiento
    private Vector3 initialPos; // Posición inicial del objeto
    private Vector3 finalPos; // Posición final del objeto

    void Start()
    {
        initialPos = transform.position;
        finalPos = initialPos;
        limitUp = initialPos.y + movementDistance*3;
        limitDown = initialPos.y - movementDistance;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            MoverArriba();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            MoverAbajo();
        }

        // Si el objeto está en movimiento, realizar la interpolación lineal
        if (onMovement)
        {
            float timeElapsed = (Time.time - timeOfMovement) / movementTime;
            transform.position = Vector3.Lerp(initialPos, finalPos, timeElapsed);

            // Verificar si se completó el movimiento
            if (timeElapsed >= 1f)
            {
                onMovement = false;
            }
        }
    }

    private float timeOfMovement; // Tiempo en que comenzó el movimiento

    void MoverArriba()
    {
        if (!onMovement)
        {
            initialPos = transform.position;
            if (initialPos.y + movementDistance <= limitUp){
                onMovement = true;
                finalPos = initialPos + Vector3.up * movementDistance;
                timeOfMovement = Time.time;
            }
        }
    }

    void MoverAbajo()
    {
        if (!onMovement)
        {
            initialPos = transform.position;
            if (initialPos.y - movementDistance >= limitDown){
                onMovement = true;
                finalPos = initialPos - Vector3.up * movementDistance;
                timeOfMovement = Time.time;
            }
        }
    }
}
