using UnityEngine;

public class ButtonState : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite OnSprite;
    public Sprite OffSprite;
    public bool on;

    private void OnTriggerStay2D(Collider2D collision)
    {
        spriteRenderer.sprite = OnSprite;
        on = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteRenderer.sprite = OffSprite;
        on = false;
    }
}
