using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject objectivesUI;
    public GameObject controlsUI;
    public bool objectivesIsShowing = false;
    public bool controlsIsShowing = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused && objectivesIsShowing is false && controlsIsShowing is false)
            {
                Resume();
            }
            else if (objectivesIsShowing)
            {
                ExitObjectives();
            }
            else if (controlsIsShowing)
            {
                ExitControls();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void ShowObjectives()
    {
        objectivesIsShowing = true;
        pauseMenuUI.SetActive(false);
        objectivesUI.SetActive(true);
    }

    public void ShowControls()
    {
        controlsIsShowing = true;
        pauseMenuUI.SetActive(false);
        controlsUI.SetActive(true);
    }

    public void ExitObjectives()
    {
        objectivesIsShowing = false;
        objectivesUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    public void ExitControls()
    {
        controlsIsShowing = false;
        controlsUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
