using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetection : MonoBehaviour
{
    [SerializeField] float restartDelay = 1f;
    [SerializeField] ParticleSystem normalcrashparticles;
    [SerializeField] Sprite CloudSprite;
    SpriteRenderer spriteRenderer;
    Movement movement;

    void Start()
    {
        spriteRenderer=GetComponent<SpriteRenderer>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Floor");
        movement = FindAnyObjectByType<Movement>();

        if(collision.gameObject.layer == layerIndex)
        {
            normalcrashparticles.Play();
            Invoke("ReloadScene" , restartDelay);
            movement.DisableControls();
        }
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(0);  
    }
}
