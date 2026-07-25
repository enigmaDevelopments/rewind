using UnityEngine;

public class KillClone : KillPlayer
{
    protected override void OnCollisionStay2D(Collision2D collision)
    {
        Kill();
    }
    public override void Kill()
    {
        base.Kill();
        dontKill = true;
        Destroy(gameObject,1);
    }
}