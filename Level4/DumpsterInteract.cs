using UnityEngine;
using UnityEngine.UI;

public class DumpsterInteract : MonoBehaviour
{
    public ToggleCrosshair defaultCircle;
    public UniversalOnEnter childOnEnter;
    public Text hoverText;
    public AudioSource dumpsterAudio;
    public GameObject trashBagHold;
    private bool alreadyDumped = false;
    public GameObject magician;
    public GameObject hideMagicianTrigger;
    public GameObject objectiveOne;
    public GameObject managerJumpScare;

    private void OnMouseDown()
    {
        if (childOnEnter.isActive && !PauseMenu.GameIsPaused && !alreadyDumped)
        {
            dumpsterAudio.Play();
            defaultCircle.SetDefault();
            hoverText.text = "";
            Destroy(trashBagHold);
            magician.SetActive(true);
            hideMagicianTrigger.SetActive(true);
            Destroy(objectiveOne);
            managerJumpScare.SetActive(true);
            alreadyDumped = true;
        }
    }

    private void OnMouseOver()
    {
        if (childOnEnter.isActive && !alreadyDumped)
        {
            defaultCircle.SetHandGrab();
            hoverText.text = gameObject.name;
        }
    }

    private void OnMouseExit()
    {
        if (childOnEnter.isActive && !alreadyDumped)
        {
            defaultCircle.SetDefault();
            hoverText.text = "";
        }
    }
}
