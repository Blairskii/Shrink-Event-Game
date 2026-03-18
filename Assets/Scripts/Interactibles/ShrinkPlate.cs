using UnityEngine;

public class ShrinkPlate : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) // When another collider enters the trigger area of the shrink plate
    {
        if (!other.CompareTag("Player")) // Check if the collider belongs to the player, if not...
            return;

        PlayerStateController stateController = other.GetComponent<PlayerStateController>(); // Get the PlayerStateController from the player
        if (stateController != null)
        {
            stateController.SetSmall(); // Set the player to small size
        }
    }
}