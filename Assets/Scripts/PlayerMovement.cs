using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Range(0, 10)] private float speed = 2;
    [SerializeField, Range(2, 10)] private float jumpForce = 3.0f;
    [SerializeField] private Transform circleCollider;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float jumpOffset;
    private SoundControl sound;
    public Rigidbody2D playerRigidbody;
    private SpriteRenderer sR;
    private GameObject let;
    private ActionController action;
    public bool isGrounded = false;
    public bool isPlayGame = true;

    private void Awake()
    {
        sound = GameObject.Find("MainCanvas").GetComponent<SoundControl>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        sR = GetComponent<SpriteRenderer>();
        Time.timeScale = 1.5f;
        isPlayGame = true;
    }

    private void FixedUpdate()
    {
        Vector2 circleTransform = circleCollider.position;
        isGrounded = Physics2D.OverlapCircle(circleTransform, jumpOffset, groundMask);
        if (Mathf.Abs(playerRigidbody.velocity.y) <= 0.05f && Mathf.Abs(playerRigidbody.velocity.x) <= 0.05f)
        {
            isGrounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        let = collision.gameObject;
        if (let.CompareTag("Switch"))
        {
            action = let.GetComponent<ActionController>();
            action.ActionUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (action != null)
        {
            action.ActionUI.SetActive(false);
            let = null;
            action = null;
        }
    }

    public void Action()
    {
        if (let.CompareTag("Switch"))
        {
            action.DoorController();
        }
    }

    public void Move(float direction, float fly, bool jump)
    {
        if (isPlayGame)
        {
            if (jump)
            {
                Jump();
            }

            if (direction != 0 || fly != 0)
            {
                if (direction > 0)
                {
                    sR.flipX = false;
                }
                else if (direction < 0)
                {
                    sR.flipX = true;
                }
                MoveCharacter(direction, fly);
            }
    }
}

    private void MoveCharacter(float direction, float fly)
    {
        playerRigidbody.velocity = new Vector2(direction * speed, playerRigidbody.velocity.y);
    }

    private void Jump()
    {
        if (isGrounded)
        {
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpForce);
            sound.JumpSound();
        }
    }
}