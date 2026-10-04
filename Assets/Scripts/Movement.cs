using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] float torqueAmount = 3f;
    InputAction moveAction;
    Rigidbody2D myRigidbody2D;
    Vector2 moveVector;
    [SerializeField] float baseSpeed = 15f;
    [SerializeField] float boostSpeed = 20f;

    SurfaceEffector2D surfaceEffector2D;
    void Start()
    {
       moveAction = InputSystem.actions.FindAction("Move");
       myRigidbody2D = GetComponent<Rigidbody2D>();
       surfaceEffector2D = FindAnyObjectByType<SurfaceEffector2D>(); // FindFirstObjectOfType has been deprecated - and the video instructions recommend that this method be used instead.
    }

    void Update()
    {
        RotatePlayer();
        BoostPlayer();
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
}
