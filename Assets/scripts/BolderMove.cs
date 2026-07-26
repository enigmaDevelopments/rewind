using Unity.VisualScripting;
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
        Move(distence);
        rb.linearVelocity = Vector2.zero;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
            return;
        velocity *= -1;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        ContactPoint2D contact = collision.GetContact(0);
        Move((.125f - contact.separation) * Mathf.Sign(contact.normal.x));
    }
    private void Move(float distence)
    {
        if (distence == 0)
            return;
        rb.MovePosition(rb.position + Vector2.right * distence);
        bolder.Rotate(0, 0, distence * -360 / Mathf.PI);
    }
}
