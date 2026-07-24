using UnityEngine;

public class OpenGate : MonoBehaviour
{
    public Transform gate;
    public float closingTime;
    public Quaternion open = Quaternion.Euler(0, 0, -90);
    public ButtonState button;
    private float lerp;

    // Update is called once per frame
    void Update()
    {
        lerp += Mathf.Abs(Timer.deltaTime) * (button.on ? 1 : -1) / closingTime;
        lerp = Mathf.Clamp01(lerp);
        gate.rotation = Quaternion.Slerp(Quaternion.identity, open, lerp);
    }
}
