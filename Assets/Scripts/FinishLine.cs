using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float delayTime = 1f;
    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Player");

        if(collision.gameObject.layer == layerIndex)
        {
            Invoke("ReloadScene" , delayTime);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);  
    }
}
