using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public static float time;
    public TMP_Text timerText;

    // Update is called once per frame
    void Update()
    {
        timerText.text = time.ToString("F4");
    }
}
