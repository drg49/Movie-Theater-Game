using UnityEngine;
using UnityEngine.UI;

public class TrashBagInteract : MonoBehaviour
{
    public ToggleCrosshair defaultCircle;
    public Text hoverText;
    public GameObject trashRatio;
    public GameObject trashBagHold;
    public AudioSource grab;

    private void OnMouseDown()
    {
        if(TrashBagOnEnter.isActive  && !PauseMenu.GameIsPaused)
        {
            trashBagHold.SetActive(true);
            trashRatio.SetActive(true);
            grab.Play();
            gameObject.SetActive(false);
            defaultCircle.SetDefault();
            hoverText.text = "";
        }
    }

    private void OnMouseOver()
    {
        if (TrashBagOnEnter.isActive)
        {
            defaultCircle.SetHandGrab();
            hoverText.text = gameObject.name;
        }
    }

    private void OnMouseExit()
    {
        if (TrashBagOnEnter.isActive)
        {
            defaultCircle.SetDefault();
            hoverText.text = "";
        }
    }
}
