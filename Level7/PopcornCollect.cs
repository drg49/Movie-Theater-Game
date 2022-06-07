using UnityEngine;
using UnityEngine.UI;

public class PopcornCollect : MonoBehaviour
{
    public ToggleCrosshair defaultCircle;
    public Text hoverText;
    public UniversalOnEnter childOnEnter;

    private void OnMouseDown()
    {
        if (childOnEnter.isActive && !PauseMenu.GameIsPaused)
        {
            Debug.Log("Hello world");
        }
    }

    private void OnMouseOver()
    {
        if (childOnEnter.isActive)
        {
            defaultCircle.SetHandGrab();
            hoverText.text = "Popcorn";
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
}
