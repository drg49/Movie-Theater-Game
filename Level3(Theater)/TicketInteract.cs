using UnityEngine;
using UnityEngine.UI;

public class TicketInteract : MonoBehaviour
{
    public ToggleCrosshair defaultCircle;
    public Text hoverText;
    public Text instructionalText;
    public string objectName;
    public static bool isHoldingTicket = false;

    public GameObject ticketHold;

    private void OnMouseDown()
    {
        if (TicketOnEnter.isActive && CustomerInteract.customerOrderStarted && !isHoldingTicket && !PauseMenu.GameIsPaused)
        {
            if (MoviesInteract.playerIsHoldingACup || MoviesInteract.playerIsHoldingPopcorn)
            {
                instructionalText.text = "Trash the item or hand it to the customer before continuing.";
                Invoke("clearInstructionalText", 4);
                return;
            }
            isHoldingTicket = true;
            MoviesInteract.playerOrder.MovieTicket = true;
            ticketHold.SetActive(true);
            defaultCircle.SetDefault();
            hoverText.text = "";
        }
    }

    private void OnMouseOver()
    {
        if (TicketOnEnter.isActive)
        {
            defaultCircle.SetHandGrab();
            hoverText.text = objectName;
        }
    }

    private void OnMouseExit()
    {
        if (TicketOnEnter.isActive)
        {
            defaultCircle.SetDefault();
            hoverText.text = "";
        }
    }

    private void clearInstructionalText()
    {
        instructionalText.text = "";
    }

}
