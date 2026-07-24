using UnityEngine;

public class BolderMove : MonoBehaviour
{
    public Transform bolder;
    public Rigidbody2D rb;
    public float velocity;

    // Update is called once per frame
    void Update()
    {
        float distence = velocity * Timer.deltaTime;
        rb.MovePosition(rb.position + Vector2.right * distence);
        bolder.Rotate(0, 0, distence * -360 / Mathf.PI);
    }
}
