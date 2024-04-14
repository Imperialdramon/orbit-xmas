using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float[] posiblesPosiciones = {25.5f, 27f, 28.5f, 30f, 31.5f};
        float nd = posiblesPosiciones[Random.Range(0, posiblesPosiciones.Length)]; 
        transform.position = transform.position.normalized * nd;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
