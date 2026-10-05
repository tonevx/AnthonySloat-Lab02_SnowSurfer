using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetection : MonoBehaviour
{
    [SerializeField] float restartDelay = 1f;
    [SerializeField] ParticleSystem crashParticles;

    Movement movement;
     void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Floor");
        movement = FindAnyObjectByType<Movement>();

        if(collision.gameObject.layer == layerIndex)
        {
            crashParticles.Play();
            Invoke("ReloadScene" , restartDelay);
            movement.DisableControls();
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);  
    }
}
