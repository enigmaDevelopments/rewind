using UnityEngine;

public class BolderMove : MonoBehaviour
{
    public Transform bolder;
    public Rigidbody2D rb;
    public float velocity;
    private float distanceMoved;

    // Update is called once per frame
    void FixedUpdate()
    {
        float distence = velocity * Timer.fixedDeltaTime;
        Move(distence);
        rb.linearVelocity = Vector2.zero;
        distanceMoved += distence;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
            return;
        velocity *= -1;
        distanceMoved = 0;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6 || distanceMoved < .125)
            return;
        Move(Mathf.Sign(velocity) * .25f);
    }
    private void Move(float distence)
    {
        rb.MovePosition(rb.position + Vector2.right * distence);
        bolder.Rotate(0, 0, distence * -360 / Mathf.PI);
    }
}
