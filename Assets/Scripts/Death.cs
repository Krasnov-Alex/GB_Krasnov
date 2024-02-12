using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPannel;
    private SoundControl sound;
    private Animator animator;
    private PlayerMovement movement;

    private void Awake()
    {
        sound = GameObject.Find("MainCanvas").GetComponent<SoundControl>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator = collision.GetComponent<Animator>();
            movement = collision.GetComponent<PlayerMovement>();
            animator.SetBool("isDead", true);
            movement.isPlayGame = false;
            gameOverPannel.SetActive(true);
            sound.GameOverSound();
        }
    }
}
