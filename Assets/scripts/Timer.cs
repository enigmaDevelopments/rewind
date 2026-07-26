using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public static float time;
    public TMP_Text timerText;
    private static float lastFrame = -1;
    private static float currentTime = -1;

    public static float realTime = 0;
    public static float relitivisticTime = 0;
    public static float outOfGameTime = 0;
    private static float lastFixedTime;
    private static float currentFixedTime;
    
    public static float deltaTime
    {
        get {
            if (lastFrame == -1)
                return 0;
            return lastFrame - currentTime;
        }
    }
    public static float fixedDeltaTime
    {
        get
        {
            if (lastFixedTime == -1)
                return 0;
            return lastFixedTime - currentFixedTime;
        }
    }

    private void Start()
    {
        lastFixedTime = -1;
        currentFixedTime = -1;
    }

    void Update()
    {
        lastFrame = currentTime;
        currentTime = time;
        timerText.text = time.ToString("F4");
        realTime += deltaTime;
        relitivisticTime += Mathf.Abs(deltaTime);
        outOfGameTime += Time.deltaTime;
    }
    private void FixedUpdate()
    {
        lastFixedTime = currentFixedTime;
        currentFixedTime = time;
    }

}
