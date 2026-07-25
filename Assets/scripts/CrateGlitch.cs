using UnityEngine;

public class CrateGlitch : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite normal;
    public Sprite glitch;

    [Range(0, 1)]
    public float chance1;
    [Range(0, 1)]
    public float chance2;
    [Range(0, 1)]
    public float chance3;
    public float cooldown;
    public float secondGlitchSeconds;

    private bool isGlitched = false;
    private bool isFirstGlitch = false;
    private float timer = 0f;
    private float cooldownTimer = 0f;


    void FixedUpdate()
    {
        if (0 < cooldownTimer)
        {
            cooldownTimer -= Time.fixedDeltaTime;
            return;
        }
        if (0 <= Timer.fixedDeltaTime && !isGlitched)
            return;
        if (isGlitched)
        {

            if (Random.value < chance2)
            {
                spriteRenderer.sprite = normal;
                isGlitched = false;
                if (isFirstGlitch)
                    timer = secondGlitchSeconds;
                cooldownTimer = cooldown;
            }
        }
        else if (0 < timer)
        {
            timer -= Time.fixedDeltaTime;
            if (Random.value < chance3)
            {
                spriteRenderer.sprite = normal;
                isGlitched = true;
                isFirstGlitch = false;
                timer = 0;
                cooldownTimer = cooldown;
            }
        }
        else
        {
            if (Random.value < chance1)
            {
                spriteRenderer.sprite = glitch;
                isGlitched = true;
                isFirstGlitch = true;
                cooldownTimer = cooldown;
            }
        }
    }
}
