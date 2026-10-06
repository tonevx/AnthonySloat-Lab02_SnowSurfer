using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    [SerializeField] PowerupSO powerup;

    Movement movement;
    
    void Start()
    {
        movement = FindAnyObjectByType<Movement>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
       int layerIndex = LayerMask.NameToLayer("Player");
       if (collision.gameObject.layer == layerIndex)
        {
            //Activate the powerup
            movement.ActivatePowerup(powerup);
        }
    }
}
