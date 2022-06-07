using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FridgeInteract : MonoBehaviour
{
    public ToggleCrosshair defaultCircle;
    public Text hoverText;
    public UniversalOnEnter childOnEnter;
    public GameObject fridgeLight;
    public AudioSource fridgeOpenAudio;
    public GameObject ratioUI;
    public List<BoxCollider> collidersToEnable;

    private static bool isDoorOpen = false;

    private void OnMouseDown()
    {
        if (childOnEnter.isActive && !IntroPauseGame.GameIsPaused && !isDoorOpen)
        {
            foreach(BoxCollider collider in collidersToEnable)
            {
                collider.enabled = true;
            }
            fridgeOpenAudio.Play();
            fridgeLight.SetActive(true);
            gameObject.GetComponent<Animator>().SetTrigger("OpenFridge");
            defaultCircle.SetDefault();
            hoverText.text = "";
            ratioUI.SetActive(true);
            isDoorOpen = true;
        }
    }

    private void OnMouseOver()
    {
        if (childOnEnter.isActive && !isDoorOpen)
        {
            defaultCircle.SetHandGrab();
            hoverText.text = "Fridge";
        }
    }

    private void OnMouseExit()
    {
        if (childOnEnter.isActive && !isDoorOpen)
        {
            defaultCircle.SetDefault();
            hoverText.text = "";
        }
    }
}
