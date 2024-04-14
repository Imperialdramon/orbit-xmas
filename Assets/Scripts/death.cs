using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class death : MonoBehaviour
{
    public Sprite spritenew;
    private SpriteRenderer spRender;
    public GameObject explotion;
    private Rotacion explotionRotacion;
    private Rotacion playerRotation;
    private bool dead = false;
    void Start(){
        spRender = gameObject.GetComponent<SpriteRenderer>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("asteroide")){
            spRender.sprite = spritenew;
            explotion.transform.position = new Vector3(transform.position.x,transform.position.y,0.5f);
            if(!dead){
                explotionRotacion = explotion.AddComponent<Rotacion>();
                playerRotation = gameObject.AddComponent<Rotacion>();
                explotionRotacion.velocidadRotacion = 100;
                playerRotation.velocidadRotacion = -100;
                Invoke("RemoveAll",2);
            }
            dead = true;
        }
    }
    void Update(){
        if(Input.GetKeyDown("r") && dead){
            ResetScreen();
        }
    }

    void RemoveAll(){
        transform.position = new Vector2(18,30);
        explotion.transform.position = new Vector2(18,30);
    }
    void ResetScreen(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
