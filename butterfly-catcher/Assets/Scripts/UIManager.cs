using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Interfaces:")]
    public GameObject[] allPanels = new GameObject[1];
    public GameManager gameManager;
    public GameObject mainMenuUI;
    public GameObject pauseMenuUI;
    public GameObject gameUI;
    public GameObject galleryUI;

    private void FixedUpdate()
    {
        gameUI.GetComponentInChildren<Text>().text = $"Score: {gameManager.score}";
    }

    public void CloseAllPanels()
    {
        for (int i = 0; i < allPanels.Length; i++)
        {
            allPanels[i].SetActive(false);
        }
    }

    public void PlayGame()
    {
        CloseAllPanels();
        gameUI.SetActive(true);

    }

    public void OpenGallery()
    {
        CloseAllPanels();
        galleryUI.SetActive(true);
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
        CloseAllPanels();
        mainMenuUI.SetActive(true);
    }

    public void BackToMenuRestart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }
}
