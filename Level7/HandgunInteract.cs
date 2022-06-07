using UnityEngine;
using UnityEngine.UI;

public class HandgunInteract : MonoBehaviour
{
    public GameObject defaultCircle;
    public GameObject pistolCrosshair;
    public Text hoverText;
    public UniversalOnEnter childOnEnter;
    public GameObject fpsHands;
    public AudioSource pistolCockAudio;
    public Text menuObjOne;

    private void OnMouseDown()
    {
        if (childOnEnter.isActive && !PauseMenu.GameIsPaused)
        {
            pistolCockAudio.Play();
            fpsHands.GetComponent<HandgunControls>().gunIsOut = true;
            fpsHands.SetActive(true);
            gameObject.SetActive(false);
            defaultCircle.GetComponent<ToggleCrosshair>().SetDefault();
            defaultCircle.SetActive(false);
            pistolCrosshair.SetActive(true);
            hoverText.text = "";
            menuObjOne.color = Color.gray;
            Destroy(gameObject);
        }
    }

    private void OnMouseOver()
    {
        if (childOnEnter.isActive)
        {
            defaultCircle.GetComponent<ToggleCrosshair>().SetHandGrab();
            hoverText.text = "Handgun";
        }
    }

    private void OnMouseExit()
    {
        if (childOnEnter.isActive)
        {
            defaultCircle.GetComponent<ToggleCrosshair>().SetDefault();
            hoverText.text = "";
        }
    }
}
