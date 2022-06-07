using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HouseDoorinteract : MonoBehaviour
{
    public ToggleCrosshair defaultCircle;
    public UniversalOnEnter childOnEnter;
    public Text hoverText;
    public AudioSource doorOpenSound;
    public string hoverTextString;
    [SerializeField] private Animator sceneFadeAnim;
    public string nextLevel;

    private bool isDoorOpen = false;

    private void OnMouseDown()
    {
        if (childOnEnter.isActive && !PauseMenu.GameIsPaused && !isDoorOpen)
        {
            isDoorOpen = true;
            doorOpenSound.Play();
            defaultCircle.SetDefault();
            hoverText.text = "";
            sceneFadeAnim.SetTrigger("ExitTrigger");
            Invoke("LoadNextLevel", 1.4f);
        }
    }

    private void OnMouseOver()
    {
        if (childOnEnter.isActive)
        {
            defaultCircle.SetHandGrab();
            hoverText.text = hoverTextString;
        }
    }

    private void OnMouseExit()
    {
        if (childOnEnter.isActive)
        {
            defaultCircle.SetDefault();
            hoverText.text = "";
        }
    }

    // Move onto level 5
    private void LoadNextLevel()
    {
        LevelManager.isLevelFour = false;
        LevelManager.isLevelFive = true;
        SceneManager.LoadScene(nextLevel);
    }
}
