using UnityEngine;

public class GrowthPlate : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) // When another collider enters the trigger area of the growth plate
    {
        if (!other.CompareTag("Player")) // Check if the collider belongs to the player, if not...
            return;

        PlayerStateController stateController = other.GetComponent<PlayerStateController>(); // Get the PlayerStateController from the player 
        if (stateController != null)
        {
            stateController.SetLarge(); // Set the player to large size
        }
    }
}