using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.SceneManagement;

public struct Location
{
    public Vector2 postiotion;
    public float time;
    public float leftLeg;
    public float rightLeg;
    public Sprite sprite;
}

public class playerMovment : MonoBehaviour
{
    

    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public PlayerInput input;
    public KillPlayer deathManager;
    public GameObject clone;
    public Sprite[] sprites;
    public Color sockColor;
    public Color powerSockColor;
    public Transform leftLeg;
    public Transform rightLeg;
    public SpriteRenderer leftSock;
    public SpriteRenderer rightSock;
    public AnimationCurve legAnimation;
    public float legOffset;
    public float legSepeation;
    public float strideHeight;
    [Range(0, 10)]
    public float speed;
    public float startingTime;
    public float animationSpeed;
    private List<Location> Locations = new List<Location>();
    private Vector2 lastDirection = Vector2.right;
    private bool rewindTap;
    private bool rewindHold;
    private bool powered;
    private bool wasRewinding;
    private List<Location> orignalLocations;

    public bool Powered
    {
        get { return powered; }
        set 
        { 
            powered = value;
            rightSock.color = leftSock.color = powered ? powerSockColor : sockColor;
        }
    }



    private void Start()
    {
        Timer.time = startingTime;
    }
    private void OnEnable()
    {
        input.actions["Rewind"].performed += OnRewindPress;
        input.actions["Rewind"].canceled += OnRewindRelease;
    }
    private void OnDisable()
    {
        input.actions["Rewind"].performed -= OnRewindPress;
        input.actions["Rewind"].canceled -= OnRewindRelease;
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
                    spriteRenderer.sprite = Locations[i].sprite;
                    leftLeg.localPosition = new Vector3(-legSepeation, Locations[i].leftLeg, 0);
                    rightLeg.localPosition = new Vector3(legSepeation, Locations[i].rightLeg, 0);
                    while (i < Locations.Count)
                        Locations.RemoveAt(Locations.Count - 1);
                    break;
                }
            }
            wasRewinding = true;
            rewindTap = false;
            return;
        }
        else if (wasRewinding)
        {
            deathManager.dontKill = false;
            wasRewinding = false;
            rb.simulated = true;
            if (powered == true)
            {
                for (int i = 1; i < Locations.Count; i++)
                    orignalLocations.RemoveAt(0);
                GameObject cloneInstance = Instantiate(clone, transform.position, Quaternion.identity);
                cloneInstance.GetComponent<CloneControler>().locations = orignalLocations.ToArray();
                Powered = false;
            }
        }
        #endregion
        if (Timer.time < 0)
        {
            Timer.time = 0;
            deathManager.Kill();
            return;
        }
        if (deathManager.dead)
            return;
        Vector2 movement = input.actions["Move"].ReadValue<Vector2>();
        bool walkInPlace = input.actions["Fast Forward"].IsPressed();
        if (movement == Vector2.zero && !walkInPlace)
            return;
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        Timer.time -= (walkInPlace? 1 : movement.magnitude) * Time.deltaTime;
        #region animation

        if (movement == Vector2.zero)
            movement = lastDirection;
        else
            lastDirection = movement;

            float leftOffset = 0;
        float rightOffset = 0.5f;
        if (Mathf.Abs(movement.y) < Mathf.Abs(movement.x))
        {
            if (movement.x < 0)
                spriteRenderer.sprite = sprites[3];

            else
            {
                spriteRenderer.sprite = sprites[1];
                leftOffset = .5f;
                rightOffset = 0;
            }
        }
        else
        {
            if (movement.y < 0)
            {
                spriteRenderer.sprite = sprites[2];
                leftOffset = .5f;
                rightOffset = 0;
            }
            else
                spriteRenderer.sprite = sprites[0];
        }

        float leftLegPosition = legOffset + legAnimation.Evaluate((startingTime - Timer.time)  * animationSpeed + leftOffset) * strideHeight;
        float rightLegPosition = legOffset + legAnimation.Evaluate((startingTime - Timer.time)  * animationSpeed + rightOffset) * strideHeight;
        leftLeg.localPosition = new Vector3(-legSepeation, leftLegPosition, 0);
        rightLeg.localPosition = new Vector3(legSepeation, rightLegPosition, 0);

        #endregion
        #region state list
        Locations.Add(
            new Location
            {
                postiotion = rb.position,
                time = Timer.time,
                sprite = spriteRenderer.sprite,
                leftLeg = leftLegPosition,
                rightLeg = rightLegPosition

            });
        #endregion
    }
    public void OnRewindPress(InputAction.CallbackContext context)
    {
        rewindTap = context.interaction is TapInteraction;
        rewindHold = context.interaction is HoldInteraction;
        deathManager.dead = false;
        deathManager.dontKill = true;
        deathManager.collider2d.enabled = true;
        deathManager.particle.Stop();
        spriteRenderer.enabled = true;
        leftSock.enabled = true;
        rightSock.enabled = true;
        orignalLocations = new List<Location>(Locations);
        rb.simulated = false;
    }
    public void OnRewindRelease(InputAction.CallbackContext context)
    {
        rewindHold = false;
    }
    public void OnReset(InputValue value)
    {
        if (value.isPressed)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
