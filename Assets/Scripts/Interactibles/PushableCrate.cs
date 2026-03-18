using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PushableCrate : MonoBehaviour, IPlayerSizeListener //
{
    private Rigidbody2D rb; // Crate's Rigidbody2D component

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component on awake
    }

    public void OnPlayerBecameSmall() 
    {
        LockCrate(); // When the player becomes small, lock the crate's horizontal movement and rotation
    }

    public void OnPlayerBecameLarge()
    {
        UnlockCrate(); // When the player becomes large, unlock the crate's horizontal movement 
    }

    private void LockCrate()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation; // Freeze horizontal movement and rotation
    }

    private void UnlockCrate()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation; // freeze rotation
    }
}