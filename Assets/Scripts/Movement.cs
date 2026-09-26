using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    InputAction moveAction;
    void Start()
    {
       moveAction = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        Vector2 moveVector;
        moveVector = moveAction.ReadValue<Vector2>();
        print(moveVector);
    }
}
