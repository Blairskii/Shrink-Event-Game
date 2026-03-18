using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{
    public UnityEvent OnPressed; // Event triggered when a crate enters
    public UnityEvent OnReleased; // Event triggered when a crate exits

    private int crateCount = 0; // Tracks the number of crates on the pressure plate

    private void OnTriggerEnter2D(Collider2D other) // When a collider enters the trigger area of the pressure plate
    {
        if (!other.CompareTag("Crate")) // Check if the collider belongs to a crate, if not...
            return;

        crateCount++; // Increase the crate count

        if (crateCount == 1) // If this is the first crate on the plate, trigger the OnPressed event
        {
            OnPressed.Invoke(); 
        }
    }

    private void OnTriggerExit2D(Collider2D other) // When a collider exits the trigger area of the pressure plate
    {
        if (!other.CompareTag("Crate")) // Check if the collider belongs to a crate, if not...
            return;

        crateCount--; // Decrease the crate count

        if (crateCount <= 0) // If there are no crates on the plate, trigger the OnReleased event
        {
            crateCount = 0;
            OnReleased.Invoke();
        }
    }
}