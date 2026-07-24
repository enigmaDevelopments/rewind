using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class playerMovment : MonoBehaviour
{
    private struct Location
    {
        public Vector2 postiotion;
        public float time;
    }

    public Rigidbody2D rb;
    public PlayerInput input;
    [Range(0, 10)]
    public float speed;
    public float startingTime;
    private List<Location> Locations = new List<Location>();
    private bool rewindTap;
    private bool rewindHold;



    private void Start()
    {
        Timer.time = startingTime;
        input.actions["Rewind"].performed += OnRewindPress;
        input.actions["Rewind"].canceled += OnRewindRelease;
    }

    private void Update()
    {
        if (rewindTap)
            Timer.time += .005f;
        else if (rewindHold)
            Timer.time += Time.deltaTime;
        if (rewindTap || rewindHold)
        {
            Timer.time = Mathf.Min(Timer.time, startingTime);
            for (int i = Locations.Count - 1; 0 <= i; i--)
            {
                if (Timer.time <= Locations[i].time)
                {
                    transform.position = Locations[i].postiotion;
                    Timer.time = Locations[i].time;
                    while (i < Locations.Count)
                        Locations.RemoveAt(Locations.Count - 1);
                    break;
                }
            }
            rewindTap = false;
            return;
        }

        if (Timer.time <= 0)
        {
            Timer.time = 0;
            return;
        }
        Vector2 movement = input.actions["Move"].ReadValue<Vector2>();
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        Timer.time -= movement.magnitude * Time.deltaTime;
        Locations.Add(
            new Location {
                postiotion = rb.position,
                time = Timer.time
            });
    }
    public void OnRewindPress(InputAction.CallbackContext context)
    {
        rewindTap = context.interaction is TapInteraction;
        rewindHold = context.interaction is HoldInteraction;
    }
    public void OnRewindRelease(InputAction.CallbackContext context)
    {
        rewindHold = false;
    }


}
