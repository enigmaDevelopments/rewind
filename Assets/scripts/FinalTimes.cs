using TMPro;
using UnityEngine;

public class FinalTimes : MonoBehaviour
{
    public TMP_Text time1;
    public TMP_Text time2;
    public TMP_Text time3;
    void Start()
    {
        time1.text = GetTime(Timer.realTime);
        time2.text = GetTime(Timer.relitivisticTime);
        time3.text = GetTime(Timer.outOfGameTime);
    }

    private string GetTime(float time)
    {
        float s = time % 60;
        float m = time / 60;
        return $"{m.ToString("F0")}:{s.ToString("00.####")}";
    }
}
