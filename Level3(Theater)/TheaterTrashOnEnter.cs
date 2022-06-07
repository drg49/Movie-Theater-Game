using UnityEngine;
using UnityEngine.UI;

public class TheaterTrashOnEnter : MonoBehaviour
{
    public bool isActive = false;
    public ToggleCrosshair defaultCircle;
    public Text hoverText;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            isActive = true;
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            isActive = false;
            hoverText.text = "";
            defaultCircle.SetDefault();
        }
    }
}
