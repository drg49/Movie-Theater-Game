using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BedInteract : MonoBehaviour
{
    public ToggleCrosshair defaultCircle;
    public Text hoverText;
    public UniversalOnEnter childOnEnter;
    [SerializeField] private Animator sceneFadeAnim;
    public string NextLevel;

    private void OnMouseDown()
    {
        // Move onto level 6
        if (childOnEnter.isActive && !IntroPauseGame.GameIsPaused)
        {
            LevelManager.isLevelSix = true;
            sceneFadeAnim.SetTrigger("ThreeHoursLater");
            Invoke("LoadNextLevel", 5.5f);
        }
    }

    private void OnMouseOver()
    {
        if (childOnEnter.isActive)
        {
            defaultCircle.SetHandGrab();
            hoverText.text = "Go to Sleep";
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

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(NextLevel);
    }
}
