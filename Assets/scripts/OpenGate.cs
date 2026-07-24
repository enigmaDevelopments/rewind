using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour
{
    private struct Position
    {
        public float roatation;
        public float time;
    }
    public Transform gate;
    public float closingTime;
    public Quaternion open = Quaternion.Euler(0, 0, -90);
    public ButtonState button;
    private List<Position> positions = new List<Position>();
    private float lerp;

    // Update is called once per frame
    void Update()
    {
        float deltaTime = Timer.deltaTime;
        if (deltaTime < 0)
        {
            for (int i = positions.Count - 1; 0 <= i; i--)
            {
                if (Timer.time <= positions[i].time)
                {
                    lerp = positions[i].roatation;
                    break;
                }
                positions.RemoveAt(i);
            }
        }
        else if (0 < deltaTime)
        {

            lerp += deltaTime * (button.on ? 1 : -1) / closingTime;
            lerp = Mathf.Clamp01(lerp);
            positions.Add(new Position
            {
                roatation = lerp,
                time = Timer.time
            });
        }
        gate.rotation = Quaternion.Slerp(Quaternion.identity, open, lerp);
    }
}
