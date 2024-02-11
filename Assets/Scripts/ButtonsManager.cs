using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsManager : MonoBehaviour
{
    [SerializeField] private GameObject pausePannel;
    [SerializeField] private Text pauseButtonText;

    public void RestartLvL()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PauseButton()
    {
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
            pausePannel.SetActive(true);
            pauseButtonText.text = "Играть";
        }
        else
        {
            Time.timeScale = 1.5f;
            pausePannel.SetActive(false);
            pauseButtonText.text = "Пауза";
        }
    }

    public void PlayGameButton()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
