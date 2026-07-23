using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovment : MonoBehaviour
{
    private Vector2 movement;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        transform.position += (Vector3)movement * Time.deltaTime;
    }

    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }
}
