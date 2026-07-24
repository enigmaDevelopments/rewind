using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public static float time;
    public TMP_Text timerText;
    private static float lastFrame = -1;
    private static float currentTime = -1;

    public static float deltaTime
    {
        get {
            if (lastFrame == -1)
                return 0;
            return (lastFrame - currentTime);
        }
    }


    // Update is called once per frame
    void Update()
    {
        lastFrame = currentTime;
        currentTime = time;
        timerText.text = time.ToString("F4");
    }

}
