using UnityEngine;
using UnityEngine.UI;

public class TrashInteract : MonoBehaviour
{
    public ToggleCrosshair defaultCircle;
    public Text hoverText;
    public Text instructionalText;

    public AudioSource trashAudio;

    // The cups the player is or isn't holding
    public GameObject smallCup;
    public GameObject largeCup;
    public GameObject smallCupLid;
    public GameObject largeCupLid;

    // The popcorn the player is or isn't holding
    public GameObject largePopcorn;
    public GameObject smallPopcorn;

    // The ticket the player is holding
    public GameObject tickethold;

    private void OnMouseDown()
    {
        if (!MoviesInteract.isMouseDisabled && TrashOnEnter.isActive && CustomerInteract.customerOrderStarted && !PauseMenu.GameIsPaused) 
        {
            if (MoviesInteract.playerIsHoldingACup)
            {
                defaultCircle.SetDefault();
                hoverText.text = "";
                MoviesInteract.playerIsHoldingACup = false;
                MoviesInteract.drinkReadyToServe = false;
                trashAudio.Play();
                if (largeCup.activeSelf)
                {
                    largeCup.SetActive(false);
                }
                if (smallCup.activeSelf)
                {
                    smallCup.SetActive(false);
                }
                if (largeCupLid.activeSelf)
                {
                    largeCupLid.SetActive(false);
                }
                if (smallCupLid.activeSelf)
                {
                    smallCupLid.SetActive(false);
                }
            }
            if (MoviesInteract.playerIsHoldingPopcorn)
            {
                defaultCircle.SetDefault();
                hoverText.text = "";
                MoviesInteract.playerIsHoldingPopcorn = false;
                trashAudio.Play();
                if (largePopcorn.activeSelf)
                {
                    largePopcorn.SetActive(false);
                }
                if (smallPopcorn.activeSelf)
                {
                    smallPopcorn.SetActive(false);
                }
            }
            if (TicketInteract.isHoldingTicket)
            {
                defaultCircle.SetDefault();
                hoverText.text = "";
                TicketInteract.isHoldingTicket = false;
                MoviesInteract.playerOrder.MovieTicket = false;
                trashAudio.Play();
                tickethold.SetActive(false);
            }
        }
    }

    private void OnMouseOver()
    {
        if (TrashOnEnter.isActive)
        {
            defaultCircle.SetHandGrab();
            hoverText.text = gameObject.name;
        }
    }

    private void OnMouseExit()
    {
        if (TrashOnEnter.isActive)
        {
            defaultCircle.SetDefault();
            hoverText.text = "";
        }
    }
}
