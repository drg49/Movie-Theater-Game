using UnityEngine;
using UnityEngine.UI;

public class CinemaDoorOnEnter : MonoBehaviour
{
    public static bool isActive;
    public ToggleCrosshair crosshair;
    public Text hoverText;

    private void OnTriggerEnter()
    {
        isActive = true;
    }

    private void OnTriggerExit()
    {
        isActive = false;
        crosshair.SetDefault();
        hoverText.text = "";
    }
}
