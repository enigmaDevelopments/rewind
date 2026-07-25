using UnityEngine;

public class BolderMove : MonoBehaviour
{
    public Transform bolder;
    public Rigidbody2D rb;
    public float velocity;

    // Update is called once per frame
    void FixedUpdate()
    {
        float distence = velocity * Timer.fixedDeltaTime;
        rb.MovePosition(rb.position + Vector2.right * distence);
        bolder.Rotate(0, 0, distence * -360 / Mathf.PI);
        rb.linearVelocity = Vector2.zero;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        velocity *= -1;
    }
}
