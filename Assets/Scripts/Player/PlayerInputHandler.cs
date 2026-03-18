using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 MoveInput { get; private set; } // Stores the current movement input from the player
    public bool JumpPressed { get; private set; } // Stores whether the jump button is currently pressed

    public void OnMove(InputAction.CallbackContext context) // Called by the Input System when the player provides movement input
    {
        MoveInput = context.ReadValue<Vector2>(); // Read the movement input as a Vector2 
    }

    public void OnJump(InputAction.CallbackContext context) // Called by the Input System when the player presses or releases the jump button
    {
        if (context.performed) // If the jump button is pressed set JumpPressed to true
        {
            JumpPressed = true; // Set JumpPressed to true when the jump action is performed
        }

        if (context.canceled) // If the jump button is released set JumpPressed to false
        {
            JumpPressed = false; // Set JumpPressed to false when the jump button is released
        }
    }
}