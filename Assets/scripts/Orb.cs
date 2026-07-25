using Unity.VisualScripting;
using UnityEngine;

public class Orb : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Collider2D collider2d;
    private bool rewinding;
    
    void Update()
    {
        if (Timer.fixedDeltaTime < 0)
            rewinding = true;
        else if(rewinding && 0 < Timer.fixedDeltaTime)
        {
            spriteRenderer.enabled = true;
            collider2d.enabled = true;
            rewinding = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        spriteRenderer.enabled = false;
        collider2d.enabled = false;
        collision.gameObject.GetComponent<playerMovment>().powerUp();
    }
}
