using UnityEngine;
using UnityEngine.UI;

public class KeyInteract : MonoBehaviour
{
    public ToggleCrosshair crosshair;
    public Text hoverText;
    public AudioSource keySound;
    [SerializeField] private Animator myAnimationController;
    public GameObject topDrawer;
    public Text objectiveOne;
    public Text objectiveTwo;
    public GameObject txtFour;

    private void OnMouseOver()
    {
        if(KeyOnEnter.isKeyActive)
        {
            crosshair.SetHandGrab();
            hoverText.text = "Cellphone";
        }
    }

    private void OnMouseExit()
    {
        if (KeyOnEnter.isKeyActive)
        {
            crosshair.SetDefault();
            hoverText.text = "";
        }
    }

    private void OnMouseDown()
    {
        if (KeyOnEnter.isKeyActive && !IntroPauseGame.GameIsPaused)
        {
            KeyOnEnter.isKeyActive = false;
            Destroy(txtFour);
            keySound.Play();
            DoorInteract.isDoorLocked = false;
            crosshair.SetDefault();
            hoverText.text = "";
            myAnimationController.SetBool("TriggerFadeIn", true);
            objectiveOne.color = Color.gray;
            objectiveTwo.color = new Color(255, 255, 255, 255);
            topDrawer.GetComponent<BoxCollider>().enabled = true;
            gameObject.SetActive(false);
        }
    }
}
