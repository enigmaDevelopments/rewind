using UnityEngine;

public class Sway : MonoBehaviour
{
    public float swayAmount;
    public float swaySpeed;
    private float offset;
    void Start()
    {
        offset = Random.Range(0f, 100f);
        if (0.5f < Random.value)
            transform.localScale = new Vector3(-1, 1, 1);


    }

    // Update is called once per frame
    void Update()
    {

        transform.eulerAngles = new Vector3(0, 0, Mathf.Sin(Timer.time * swaySpeed + offset) * swayAmount);

    }

}
