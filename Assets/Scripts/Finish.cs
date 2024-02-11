using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject endGamePannel;
    private Animator animator;
    private PlayerMovement movement;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetBool("isHero", true);
            movement = collision.GetComponent<PlayerMovement>();
            movement.isPlayGame = false;
            endGamePannel.SetActive(true);
        }
    }
}
