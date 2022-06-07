using UnityEngine;
using UnityEngine.UI;

public class FoodInteract : MonoBehaviour
{
    public ToggleCrosshair defaultCircle;
    public Text hoverText;
    public UniversalOnEnter childOnEnter;
    public Transform holdItem;

    private void OnMouseDown()
    {
        if (childOnEnter.isActive && !IntroPauseGame.GameIsPaused)
        {
            Destroy(gameObject.GetComponent<BoxCollider>());
            defaultCircle.SetDefault();
            hoverText.text = "";
            gameObject.GetComponent<Consumer>().enabled = true;
        }
    }

    private void OnMouseOver()
    {
        if (childOnEnter.isActive)
        {
            defaultCircle.SetHandGrab();
            hoverText.text = gameObject.name;
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
