using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private readonly float[] potentialPositions = {25.5f, 27f, 28.5f, 30f};

    private Collider2D ast;
    
    // Start is called before the first frame update
    //void Start()
    //{
    //    SetPosition();
    //}
    // On collide the wall the asteroids change the position
    void OnTriggerEnter2D(Collider2D collision){
        ast = collision.GetComponent<Collider2D>();

        if(ast.CompareTag("Wall")){
            SetPosition();
        }

        else if(ast.CompareTag("asteroide")){
            SetPosition();
        }

    }

    void OnTriggerStay2D(Collider2D collision){
        if(collision.GetComponent<Collider2D>().CompareTag("asteroide")){
            SetPosition();
        }
    }

    // Set new position from the array
    void SetPosition(){
        float nd = potentialPositions[Random.Range(0, potentialPositions.Length)]; 
        transform.position = transform.position.normalized * nd;
    }
}
