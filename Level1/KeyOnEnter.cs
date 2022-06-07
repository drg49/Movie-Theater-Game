using UnityEngine;
using UnityEngine.UI;

public class KeyOnEnter : MonoBehaviour
{
    public static bool isKeyActive = false;
    public ToggleCrosshair crosshair;
    public Text hoverText;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            isKeyActive = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            isKeyActive = false;
            crosshair.SetDefault();
            hoverText.text = "";
        }
    }
}
