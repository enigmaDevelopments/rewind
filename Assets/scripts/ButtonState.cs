using UnityEngine;

public class ButtonState : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite OnSprite;
    public Sprite OffSprite;
    public bool on;

    protected virtual void OnTriggerStay2D(Collider2D collision)
    {
        TurnOn();
    }
    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        TurnOff();
    }
    public void TurnOn()
    {
        spriteRenderer.sprite = OnSprite;
        on = true;
    }
    public void TurnOff()
    {
        spriteRenderer.sprite = OffSprite;
        on = false;
    }
}
