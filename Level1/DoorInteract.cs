using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorInteract : MonoBehaviour
{
    public ToggleCrosshair crosshair;
    public static bool isDoorLocked = true;
    public AudioSource lockedDoorSound;
    public AudioSource doorOpenSound;
    [SerializeField] private Animator myAnimationController;
    private bool isDoorOpen = false;
    public string NextLevel;
    public string hoverTextString;
    public Text hoverText;

    private void OnMouseOver()
    {
        if (DoorOnEnter.isDoorActive && !isDoorOpen)
        {
            crosshair.SetHandGrab();
            hoverText.text = hoverTextString;
        }
    }

    private void OnMouseExit()
    {
        if (DoorOnEnter.isDoorActive)
        {
            crosshair.SetDefault();
            hoverText.text = "";
        }
    }

    private void OnMouseDown()
    {
        if (DoorOnEnter.isDoorActive && isDoorLocked && !IntroPauseGame.GameIsPaused)
        {
            lockedDoorSound.Play();
        }
        else if (DoorOnEnter.isDoorActive && !isDoorLocked && !IntroPauseGame.GameIsPaused)
        {
            DoorOnEnter.isDoorActive = false;
            isDoorLocked = true;
            isDoorOpen = true;
            crosshair.SetDefault();
            hoverText.text = "";
            myAnimationController.SetTrigger("ExitTrigger");
            doorOpenSound.Play();
            Invoke("LoadNextLevel", 1.4f);
        }
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(NextLevel);
    }
}
