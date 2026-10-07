using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] float torqueAmount = 3f;
    InputAction moveAction;
    Rigidbody2D myRigidbody2D;
    Vector2 moveVector;
    ScoreManager scoreManager;
    [SerializeField] float baseSpeed = 15f;
    [SerializeField] float boostSpeed = 20f;
    [SerializeField] ParticleSystem powerupParticles;
    public bool canControlPlayer = true;
    float previousRotation;
    float totalRotation;
    int activePowerupCount;


    SurfaceEffector2D surfaceEffector2D;
    void Start()
    {
       moveAction = InputSystem.actions.FindAction("Move");
       myRigidbody2D = GetComponent<Rigidbody2D>();
       surfaceEffector2D = FindAnyObjectByType<SurfaceEffector2D>(); // FindFirstObjectOfType has been deprecated - and the video instructions recommend that this method be used instead.
       scoreManager = FindAnyObjectByType<ScoreManager>();
    }

    void Update()
    {
        if (canControlPlayer)
        {
            RotatePlayer();
            BoostPlayer();
            CalculateFlips();
        }
    }

    void RotatePlayer()
    {
        moveVector = moveAction.ReadValue<Vector2>();
        if(moveVector.x < 0)
        {
            myRigidbody2D.AddTorque(torqueAmount);
        }
        else if(moveVector.x > 0)
        {
            myRigidbody2D.AddTorque(-torqueAmount);
        }  
    }


    void BoostPlayer()
    {
        if(moveVector.y > 0)
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }

    void CalculateFlips()
    {
        float currentRotation = transform.rotation.eulerAngles.z;
        totalRotation += Mathf.DeltaAngle(previousRotation, currentRotation);
        if(totalRotation > 340 || totalRotation < -340)
        {
            totalRotation = 0;
            scoreManager.AddScore(100);
        }
        previousRotation = currentRotation;
    }

    public void DisableControls()
    {
        canControlPlayer = false;
    }

    public void ActivatePowerup(PowerupSO powerup)
    {
        powerupParticles.Play();
        activePowerupCount += 1;
        if(powerup.GetPowerupType() == "speed")
        {
            baseSpeed += powerup.GetValueChange();
            boostSpeed += powerup.GetValueChange();
        }
        else if (powerup.GetPowerupType() == "torque")
        {
            torqueAmount += powerup.GetValueChange();
        }
    }
    public void DeactivatePowerup(PowerupSO powerup)
    {
        activePowerupCount -= 1;
        if (activePowerupCount == 0)
        {
            powerupParticles.Stop();
        }
        if(powerup.GetPowerupType() == "speed")
        {
            baseSpeed -= powerup.GetValueChange();
            boostSpeed -= powerup.GetValueChange();
        }
        else if (powerup.GetPowerupType() == "torque")
        {
            torqueAmount -= powerup.GetValueChange();
        }
    }
}
