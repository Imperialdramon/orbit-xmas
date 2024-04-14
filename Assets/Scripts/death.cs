using UnityEngine;
using UnityEngine.SceneManagement;
public class Death : MonoBehaviour
{
    public Sprite spritenew;
    public GameObject clock;
    private SpriteRenderer spRender;
    public GameObject explotion;
    private Rotation explotionRotacion;
    private Rotation playerRotation;
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
                Destroy(gameObject.GetComponent<Movement>());
                Destroy(clock.GetComponent<Timer>());
                explotionRotacion = explotion.AddComponent<Rotation>();
                playerRotation = gameObject.AddComponent<Rotation>();
                explotionRotacion.rotationSpeed = 100;
                playerRotation.rotationSpeed = -100;
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
