using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionController : MonoBehaviour
{
    [SerializeField] private GameObject let;
    [SerializeField] public GameObject ActionUI;
    private SoundControl sound;
    private bool openDoor = false;
    private Animator animator;

    private void Awake()
    {
        sound = GameObject.Find("MainCanvas").GetComponent<SoundControl>();
        animator = GetComponent<Animator>();
    }


    public void DoorController()
    {
        if (!openDoor)
        {
            openDoor = true;
            animator.SetBool("SwitchOn", true);
            sound.SwitchSound();
            let.SetActive(false);
        }
        else
        {
            openDoor = false;
            animator.SetBool("SwitchOn", false);
            sound.SwitchSound();
            let.SetActive(true);
        }
    }
}
