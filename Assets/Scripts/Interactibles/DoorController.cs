using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Collider2D doorCollider; // Collider that blocks the door in inspector
    [SerializeField] private SpriteRenderer doorSprite; // SpriteRenderer for the door's visual representation in inspector

    private void Reset() // Called when the component is added or reset in the inspector
    {
        doorCollider = GetComponent<Collider2D>(); // Automatically assign the Collider2D component if it exists
        doorSprite = GetComponent<SpriteRenderer>(); // Automatically assign the SpriteRenderer component if it exists
    }

    public void OpenDoor()
    {
        if (doorCollider != null) 
            doorCollider.enabled = false; // Disable the collider to allow passage through the door

        if (doorSprite != null) 
            doorSprite.enabled = false; // Disable the sprite to visually 
    }

    public void CloseDoor() // Method to close the door, re-enabling the collider and sprite
    {
        if (doorCollider != null)
            doorCollider.enabled = true; // Enable the collider to block passage through the door

        if (doorSprite != null)
            doorSprite.enabled = true; // Enable the sprite to visually represent the closed door
    }
}