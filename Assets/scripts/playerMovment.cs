using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovment : MonoBehaviour
{
    [Range(0, 10)]
    public float speed;
    public float startingTime; 
    private Vector2 movement;

    private void Start()
    {
        Timer.time = startingTime;
    }

    private void Update()
    {
        if (Timer.time <= 0)
        {
            Timer.time = 0;
            return;
        }
        transform.position += (Vector3)movement * speed * Time.deltaTime;
        Timer.time -= movement.magnitude * Time.deltaTime;
    }

    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }


}
