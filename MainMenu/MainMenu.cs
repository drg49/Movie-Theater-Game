using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string IntroScene;
    public GameObject loadingGraphic;
    public List<GameObject> guiItemsToHide;

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void StartNewGame()
    {
        foreach(GameObject gui in guiItemsToHide)
        {
            gui.SetActive(false);
        }
        loadingGraphic.SetActive(true);
        SceneManager.LoadSceneAsync(IntroScene);
    }

    public void LoadCredits()
    {
        Debug.Log("Loading Credits");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
