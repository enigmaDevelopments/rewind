using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Collider2D collider2d;
    public ParticleSystem particle;
    public SpriteRenderer leftLeg;
    public SpriteRenderer rightLeg;
    public bool dead;
    public bool dontKill;

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer != 7)
            return;
        Kill();
    }
    public void Kill()
    {
        if (dontKill)
            return;
        dead = true;
        collider2d.enabled = false;
        particle.Play();
        spriteRenderer.enabled = false;
        leftLeg.enabled = false;
        rightLeg.enabled = false;
    }

}
