using UnityEngine;

public class KillClone : KillPlayer
{
    protected override void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 11 && -.25f < collision.GetContact(0).separation)
            return;
        Kill();
    }
    public override void Kill()
    {
        base.Kill();
        dontKill = true;
        Destroy(gameObject,1);
    }
}