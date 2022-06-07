using UnityEngine;
using UnityEngine.UI;

public class TheaterTrashInteract : MonoBehaviour
{
    public ToggleCrosshair defaultCircle;
    public TheaterTrashOnEnter childOnEnter;
    public Text hoverText;
    public Text trashRatio;
    public AudioSource successAudio;

    private void OnMouseDown()
    {
        if (childOnEnter.isActive == true && !PauseMenu.GameIsPaused)
        {
            TrashRatio.addToRatio = true;
            successAudio.Play();
            gameObject.SetActive(false);
            defaultCircle.SetDefault();
            hoverText.text = "";
        }
    }

    private void OnMouseOver()
    {
        if (childOnEnter.isActive == true)
        {
            defaultCircle.SetHandGrab();
            hoverText.text = "Trash";
        }
    }

    private void OnMouseExit()
    {
        if (childOnEnter.isActive == true)
        {
            defaultCircle.SetDefault();
            hoverText.text = "";
        }
    }
}
