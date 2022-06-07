using UnityEngine;
using UnityEngine.UI;

public class TvOnEnter : MonoBehaviour
{
    public ToggleCrosshair crosshair;
    public static bool IsTvActive = false;
    public Text hoverText;

    private void OnTriggerEnter()
    {
        IsTvActive = true;
    }

    private void OnTriggerExit()
    {
        IsTvActive = false;
        crosshair.SetDefault();
        hoverText.text = "";
    }
}
