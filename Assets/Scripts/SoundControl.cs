using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoundControl : MonoBehaviour
{
    [SerializeField] private AudioSource fontAudio;
    [SerializeField] private AudioSource menuAudio;
    [SerializeField] private AudioSource clickAudio;
    [SerializeField] private AudioSource gameOverAudio;
    [SerializeField] private AudioSource gameWinAudio;
    [SerializeField] private AudioSource jumpAudio;
    [SerializeField] private AudioSource switchAudio;
    [SerializeField] private Text soundButtonText;
    [SerializeField] private GameObject audioGame;

    private void Start()
    {
        if ((SceneManager.GetActiveScene().buildIndex) == 0)
        {
            fontAudio.Stop();
            menuAudio.volume = 0.5f;
            menuAudio.Play();
        }
        else
        {
            menuAudio.Stop();
            fontAudio.Play();
        }
    }

    public void GameOverSound()
    {
        gameOverAudio.Play();
    }

    public void GameWinSound()
    {
        gameWinAudio.Play();
    }

    public void JumpSound()
    {
        jumpAudio.Play();
    }

    public void SwitchSound()
    {
        switchAudio.Play();
    }

    public void PauseAudio()
    {
        if (fontAudio.volume == 1)
        {
            audioGame.SetActive(false);
            fontAudio.volume = 0;
            soundButtonText.text = "Звук: OFF";
        }
        else
        {
            audioGame.SetActive(true);
            fontAudio.volume = 1;
            soundButtonText.text = "Звук: ON";
        }
    }

    public void ClickButton()
    {
        if (audioGame.active)
        {
            clickAudio.Play();
        }

    }
}
