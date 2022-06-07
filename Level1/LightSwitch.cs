using UnityEngine;
using UnityEngine.UI;

public class LightSwitch : MonoBehaviour
{
    public Light lampLight;
    public AudioSource sound;
    public ToggleCrosshair crosshair;
    public string hoverTextString;
    public Text hoverText;

    private bool OnMouseDown()
    {
        if (LightOnEnter.isLampActive && !IntroPauseGame.GameIsPaused)
        {
            sound.Play();
            crosshair.SetDefault();
            hoverText.text = "";
            if (lampLight.enabled)
            {
                return lampLight.enabled = false;
            }
            return lampLight.enabled = true;
        }
        return false;
    }

    private void OnMouseOver()
    {
        if (LightOnEnter.isLampActive)
        {
            crosshair.SetHandGrab();
            hoverText.text = hoverTextString;
        }
    }

    private void OnMouseExit()
    {
        if (LightOnEnter.isLampActive)
        {
            crosshair.SetDefault();
            hoverText.text = "";
        }
    }

}
