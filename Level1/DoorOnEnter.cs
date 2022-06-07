using UnityEngine;
using UnityEngine.UI;

public class DoorOnEnter : MonoBehaviour
{
    public static bool isDoorActive = false;
    public ToggleCrosshair crosshair;
    public Text hoverText;

    private void OnTriggerEnter()
    {
        isDoorActive = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isDoorActive = false;
        crosshair.SetDefault();
        hoverText.text = "";
    }
}
