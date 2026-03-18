using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController2D : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // Player's horizontal movement speed
    [SerializeField] private float jumpForce = 8f;  // Force applied to the player when jumping
    [SerializeField] private Transform groundCheck;   // Position from which to check if the player is grounded
    [SerializeField] private float groundCheckRadius = 0.2f; // Radius of the circle used to check for ground collision
    [SerializeField] private LayerMask groundLayer; // Layer mask to specify which layers are considered ground for the player

    private Rigidbody2D rb;
    private PlayerInputHandler inputHandler;
    private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputHandler = GetComponent<PlayerInputHandler>(); // Ensure the PlayerInputHandler component is on the same GameObject
    }

    private void Update()
    {
        CheckGround(); //   Check if the player is grounded before allowing jumps

        if (inputHandler.JumpPressed && isGrounded) // If the jump button is pressed and the player is grounded, apply a vertical force to make the player jump
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Set the player's vertical velocity to the jump force
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(inputHandler.MoveInput.x * moveSpeed, rb.velocity.y); // Set the player's horizontal velocity based on the movement input and move speed
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer); // Check if there are any colliders within the ground check radius that belong to the ground layer, and set isGrounded accordingly
    }

  
}