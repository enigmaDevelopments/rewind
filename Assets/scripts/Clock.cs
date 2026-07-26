using UnityEngine;

public class Clock : MonoBehaviour
{
    public Transform minuteHand;
    public Transform secondHand;
    public SpriteRenderer minuteSprite;
    public SpriteRenderer secondSprite;
    void Update()
    {
        float s = (Timer.realTime % 60) * -6;
        float m = Timer.realTime * -.1f;
        secondHand.rotation = Quaternion.Euler(0, 0, s);
        minuteHand.rotation = Quaternion.Euler(0, 0, m);
        Color color = Color.white;
        color.a = Mathf.PerlinNoise(s, m) *.75f +.25f;
        minuteSprite.color = color;
        color = Color.white;
        color.a = Mathf.PerlinNoise(m, s) * .75f + .25f;
        secondSprite.color = color;

    }
}
