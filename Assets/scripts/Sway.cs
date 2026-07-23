using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Sway : MonoBehaviour
{
    public float swayAmount;
    public float swaySpeed;
    public float offset;
    void Start()
    {
        offset = Random.Range(0f, 100f);
        GetComponent<SpriteRenderer>().flipX = 0.5f < Random.value;
    }

    // Update is called once per frame
    void Update()
    {

        transform.eulerAngles = new Vector3(0, 0, Mathf.Sin(Timer.time * swaySpeed + offset) * swayAmount);

    }

}
