using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    [SerializeField] PowerupSO powerup;

    Movement movement;
    SpriteRenderer spriteRenderer;
    float timeleft;
    
    void Start()
    {
        movement = FindAnyObjectByType<Movement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        timeleft = powerup.GetTime();
    }

    void Update()
    {
        CountdownTimer();
    }

    void CountdownTimer()
    {
        if(spriteRenderer.enabled == false)
        {
            if (timeleft > 0)
            {
                timeleft -= Time.deltaTime;
                print(timeleft);

                if(timeleft <= 0)
                {
                    movement.DeactivatePowerup(powerup);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
       int layerIndex = LayerMask.NameToLayer("Player");
       if (collision.gameObject.layer == layerIndex && spriteRenderer.enabled)
        {
            spriteRenderer.enabled = false;
            movement.ActivatePowerup(powerup);
        }
    }
}
