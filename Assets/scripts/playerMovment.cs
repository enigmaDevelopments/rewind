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
        public Sprite sprite;
        public bool flip;
    }

    public Rigidbody2D rb;
    public SpriteRenderer spriterRenderer;
    public PlayerInput input;
    public Sprite[] sprites;
    [Range(0, 10)]
    public float speed;
    public float startingTime;
    public float animationSpeed;
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
        rb.linearVelocity = Vector2.zero;
        #region rewind
        if (rewindTap)
            Timer.time += .01f;
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
                    spriterRenderer.sprite = Locations[i].sprite;
                    spriterRenderer.flipX = Locations[i].flip;
                    while (i < Locations.Count)
                        Locations.RemoveAt(Locations.Count - 1);
                    break;
                }
            }
            rewindTap = false;
            return;
        }
        #endregion
        if (Timer.time <= 0)
        {
            Timer.time = 0;
            return;
        }
        Vector2 movement = input.actions["Move"].ReadValue<Vector2>();
        if (movement == Vector2.zero)
            return;
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        Timer.time -= movement.magnitude * Time.deltaTime;
        #region animation
       
        int footState = Mathf.FloorToInt((startingTime - Timer.time) * animationSpeed) % 4;
        if (Mathf.Abs(movement.y) < Mathf.Abs(movement.x))
        {
            spriterRenderer.sprite = sprites[0];
            if (movement.x < 0)
            {
                spriterRenderer.flipX = true;
                if (footState == 1)
                    spriterRenderer.sprite = sprites[1];
                else if (footState == 3)
                    spriterRenderer.sprite = sprites[2];
            }
            else
            {
                spriterRenderer.flipX = false;
                if (footState == 1)
                    spriterRenderer.sprite = sprites[2];
                else if (footState == 3)
                    spriterRenderer.sprite = sprites[1];
            }
        }
        else
        {
            if (movement.y < 0)
            {
                if (footState == 0 || footState == 2)
                    spriterRenderer.sprite = sprites[5];
                else
                {
                    spriterRenderer.sprite = sprites[6];
                    spriterRenderer.flipX = footState == 1;
                }
            }
            else
            {
                if (footState == 0 || footState == 2)
                    spriterRenderer.sprite = sprites[3];
                else
                {
                    spriterRenderer.sprite = sprites[4];
                    spriterRenderer.flipX = footState == 3;
                }
            }
        }
        
        #endregion
        #region state list
        Locations.Add(
            new Location
            {
                postiotion = rb.position,
                time = Timer.time,
                sprite = spriterRenderer.sprite,
                flip = spriterRenderer.flipX

            });
        #endregion
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
