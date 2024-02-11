using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private PlayerMovement player;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if ((player.isGrounded))
        {
            animator.SetBool("isGrounded", true);
        }
        else
        {
            animator.SetBool("isGrounded", false);
        }

        if (Mathf.Abs(player.playerRigidbody.velocity.x) > 0.05f) 
        {
            animator.SetFloat("Velocity", 1f);
        }
        else
        {
            animator.SetFloat("Velocity", 0);
        }

    }
}
