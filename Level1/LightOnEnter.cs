using UnityEngine;
using UnityEngine.UI;

public class LightOnEnter : MonoBehaviour
{
    public static bool isLampActive = false;
    public ToggleCrosshair crosshair;
    public Text hoverText;

    private void OnTriggerEnter()
    {
        isLampActive = true;
    }

    private void OnTriggerExit()
    {
        isLampActive = false;
        crosshair.SetDefault();
        hoverText.text = "";
    }
}
