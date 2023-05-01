using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{

    private Vector2 movementDirection = Vector2.zero;
    private bool isJumping = false;


    public void OnMove(InputAction.CallbackContext context)
    {
        this.movementDirection = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        isJumping = context.performed;
    }

    public Vector2 GetMovement()
    {
        return movementDirection;
    }

    public bool IsJumping()
    {
        return isJumping;
    }
}
