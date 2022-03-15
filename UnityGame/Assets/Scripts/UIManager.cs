using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Interfaces:")]
    public GameManager gameManager;
    public GameObject mainMenuUI;
    public GameObject pauseMenuUI;
    public GameObject gameUI;

    void Update()
    {
        gameUI.GetComponentInChildren<Text>().text = $"Score: {gameManager.score}";
    }

    public void PlayGame()
    {
        mainMenuUI.SetActive(false);
        gameUI.SetActive(true);

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        gameManager.gameIsPaused = true;
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        gameManager.gameIsPaused = false;
        Time.timeScale = 1f;
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }
}
