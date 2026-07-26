using UnityEngine;

public class KillClone : KillPlayer
{
    public Transform rigidBody;
    protected override void OnCollisionStay2D(Collision2D collision)
    {
        return;
    }
    void FixedUpdate()
    {
        if (.25 < Vector2.Distance(transform.position, rigidBody.position))
            Kill();
    }
    public override void Kill()
    {
        base.Kill();
        dontKill = true;
        Destroy(gameObject,1);
    }
}