using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionController : MonoBehaviour
{
    [SerializeField] private GameObject let;
    [SerializeField] public GameObject ActionUI;
    private bool openDoor = false;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    public void DoorController()
    {
        if (!openDoor)
        {
            openDoor = true;
            animator.SetBool("SwitchOn", true);
            let.SetActive(false);
        }
        else
        {
            openDoor = false;
            animator.SetBool("SwitchOn", false);
            let.SetActive(true);
        }
    }
}
