using UnityEngine;

public class StopBox : MonoBehaviour
{
    public Rigidbody2D rb;
    void FixedUpdate()
    {
       rb.linearVelocity = Vector2.zero;
    }
}
 