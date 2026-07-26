using UnityEngine;

public class Orb : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Collider2D collider2d;

    void OnTriggerEnter2D(Collider2D collision)
    {
        playerMovment player = collision.gameObject.GetComponent<playerMovment>();
        if (player.Powered)
            return;
        spriteRenderer.enabled = false;
        collider2d.enabled = false;
        player.Powered = true;
    }
}
