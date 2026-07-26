using UnityEngine;

public class CloneControler : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer SpriteRenderer;
    public Transform leftLeg;
    public Transform rightLeg;
    public float legSepeation;
    public Location[] locations;
    private int lastIndex;

    private void FixedUpdate()
    {
        int i = lastIndex;
        for (; i < locations.Length - 1; i++)
            if (Mathf.Abs(Timer.time - locations[i].time) < Mathf.Abs(Timer.time - locations[i + 1].time))
                break;
        for (; 0 < i; i--)
            if (Mathf.Abs(Timer.time - locations[i].time) < Mathf.Abs(Timer.time - locations[i - 1].time))
                break;
        lastIndex = i;

        rb.MovePosition(locations[lastIndex].postiotion);
        transform.position = locations[lastIndex].postiotion;
        SpriteRenderer.sprite = locations[lastIndex].sprite;
        leftLeg.localPosition = new Vector3(-legSepeation, locations[lastIndex].leftLeg, 0);
        rightLeg.localPosition = new Vector3(legSepeation, locations[lastIndex].rightLeg, 0);
    }
}
