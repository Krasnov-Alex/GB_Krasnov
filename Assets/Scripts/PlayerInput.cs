using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        bool isjumpButtonPressed = Input.GetButtonDown("Jump");
        playerMovement.Move(horizontal, vertical, isjumpButtonPressed);
        if (Input.GetKeyDown(KeyCode.Escape))
        {

        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            playerMovement.Action();
        }
    }
}

