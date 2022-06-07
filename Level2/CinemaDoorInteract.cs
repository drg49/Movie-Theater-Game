using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CinemaDoorInteract : MonoBehaviour
{
    public ToggleCrosshair crosshair;
    public AudioSource doorOpenSound;
    [SerializeField] private Animator animController;
    private bool isDoorOpen = false;
    public string NextLevel;
    public string hoverTextString;
    public Text hoverText;

    private void OnMouseOver()
    {
        if (CinemaDoorOnEnter.isActive && !isDoorOpen)
        {
            crosshair.SetHandGrab();
            hoverText.text = hoverTextString;
        }
    }

    private void OnMouseExit()
    {
        if (CinemaDoorOnEnter.isActive)
        {
            crosshair.SetDefault();
            hoverText.text = "";
        }
    }

    private void OnMouseDown()
    {
        if(CinemaDoorOnEnter.isActive && !isDoorOpen && !PauseMenu.GameIsPaused) // crucial
        {
            isDoorOpen = true;
            crosshair.SetDefault();
            hoverText.text = "";
            animController.SetTrigger("ExitTrigger");
            doorOpenSound.Play();
            Invoke("LoadNextLevel", 1.4f);
        }
    }
    private void LoadNextLevel()
    {
        SceneManager.LoadScene(NextLevel);
    }
}
