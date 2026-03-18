using UnityEngine;

public class VentBlocker : MonoBehaviour, IPlayerSizeListener //listens for player size changes
{
    [SerializeField] private Collider2D blockCollider; 
    [SerializeField] private SpriteRenderer blockSprite;

    private void Reset()
    { 
        blockCollider = GetComponent<Collider2D>(); 
        blockSprite = GetComponent<SpriteRenderer>();
    }

    public void OnPlayerBecameSmall() //called when the player becomes small, disables the block to allow passage
    {
        DisableBlock(); 
    }

    public void OnPlayerBecameLarge() //called when the player becomes large, enables the block to prevent passage
    {
        EnableBlock();
    }

    private void EnableBlock() //enables the block's collider and sprite to make it solid and visible
    {
        if (blockCollider != null)
            blockCollider.enabled = true;

        if (blockSprite != null)
            blockSprite.enabled = true;
    }

    private void DisableBlock() //disables the block's collider and sprite to make it non-solid and invisible
    {
        if (blockCollider != null)
            blockCollider.enabled = false;

        if (blockSprite != null)
            blockSprite.enabled = false;
    }
}