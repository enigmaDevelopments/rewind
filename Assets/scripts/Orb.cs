using UnityEngine;

public class Orb : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Collider2D collider2d;

    void OnTriggerEnter2D(Collider2D collision)
    {
        spriteRenderer.enabled = false;
        collider2d.enabled = false;
        collision.gameObject.GetComponent<playerMovment>().powerUp();
    }
}
