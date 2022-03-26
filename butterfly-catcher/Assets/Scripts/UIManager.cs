using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [System.Serializable]
    public class UIElements
    {
        public string name;
        public GameObject element;
    }

    public GameManager gameManager;
    [Header("Background:")]
    public GameObject background;
    [Header("Interfaces:")]
    public UIElements[] allPanels;

    private void Start()
    {
        var heing = Camera.main.orthographicSize * 2f;
        var width = heing * Screen.width / Screen.height;
        background.transform.localScale = new Vector3(width, heing, 0);
    }

    private void FixedUpdate()
    {
        // gameUI.GetComponentInChildren<Text>().text = $"Score: {gameManager.score}";
    }

    private void CloseAllPanels()
    {
        for (int i = 0; i < allPanels.Length; i++)
        {
            allPanels[i].element.SetActive(false);
        }
    }

    public void OpenElement(string name)
    {
        for (int i = 0; i < allPanels.Length; i++)
        {
            if (allPanels[i].name == name)
            {
                allPanels[i].element.SetActive(true);
                return;
            }
        }
        Debug.LogError($"Element \"{name}\" not found.");
    }

    public void OpenElementWithPause(string name)
    {
        CloseAllPanels();
        OpenElement(name);
        Time.timeScale = 0f;
    }

    public void OpenElementWithResume(string name)
    {
        CloseAllPanels();
        OpenElement(name);
        Time.timeScale = 1f;
    }

    public void OpenScene(string sceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    
}
