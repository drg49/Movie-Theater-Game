using UnityEngine;
using UnityEngine.UI;

public class CustomerInteract : MonoBehaviour
{
    [SerializeField] private TextAsset customerInkJson;
    public GameObject cameraToActivate;
    public GameObject player;
    public Image defaultCircle;
    public Text dialoguePanelName;
    public Text hoverText;
    public string npcName;

    public AudioSource successAudio;
    public AudioSource failureAudio;

    // Items on the Order List UI
    public GameObject orderListMovieTicket;
    public GameObject orderListPopcorn;
    public GameObject orderListDrink;

    // Items the player is holding;
    public GameObject ticketHold;
    public GameObject smallPopcornHold;
    public GameObject largePopcornHold;
    public GameObject smallDrinkHold;
    public GameObject largeDrinkHold;

    // Checks if the events for customer are currently being played
    public static bool customerOrderStarted = false;

    // If customer ones orders have been fulfilled;
    public static bool custTicketFulfilled = false;
    public static bool custPopcornFulfilled = false;
    public static bool custDrinkFulfilled = false;

    public static CustomerOrder order;

    public bool MovieTicketOrder;
    public string PopcornOrder;
    public string DrinkOrder;

    private void OnMouseDown()
    {
        if (CustomerOnEnter.isCustomerActive && RegisterTarget.hasEnteredCollider && !PauseMenu.GameIsPaused)
        {
            if (MoviesInteract.playerIsHoldingPopcorn && !custPopcornFulfilled)
            {
                // Check to see if you fulfilled the customers order (popcorn)
                if (order.Popcorn == MoviesInteract.playerOrder.Popcorn) // Popcorn success
                {
                    custPopcornFulfilled = true;
                    successAudio.Play();
                    orderListPopcorn.GetComponent<Text>().color = Color.black;
                    orderListPopcorn.transform.GetChild(0).gameObject.SetActive(true); // Display green checkmark
                    MoviesInteract.playerIsHoldingPopcorn = false;
                    smallPopcornHold.SetActive(false);
                    largePopcornHold.SetActive(false);
                    return;
                }
                // Popcorn failure
                failureAudio.Play();
                orderListPopcorn.GetComponent<Text>().color = Color.red;
                return;
            }
            if (MoviesInteract.playerIsHoldingACup && MoviesInteract.drinkReadyToServe && !custDrinkFulfilled)
            {
                // Check to see if you fulfilled the customers order (drinks)
                if (order.Drink == MoviesInteract.playerOrder.Drink) // Drink success
                {
                    custDrinkFulfilled = true;
                    successAudio.Play();
                    MoviesInteract.drinkReadyToServe = false;
                    orderListDrink.GetComponent<Text>().color = Color.black;
                    orderListDrink.transform.GetChild(0).gameObject.SetActive(true); // Display green checkmark
                    MoviesInteract.playerIsHoldingACup = false;
                    smallDrinkHold.SetActive(false);
                    largeDrinkHold.SetActive(false);
                    return;
                }
                // Drink failure
                failureAudio.Play();
                orderListDrink.GetComponent<Text>().color = Color.red;
                return;
            }
            if (TicketInteract.isHoldingTicket && !custTicketFulfilled)
            {
                if (order.MovieTicket && MoviesInteract.playerOrder.MovieTicket)
                {
                    custTicketFulfilled = true;
                    successAudio.Play();
                    orderListMovieTicket.GetComponent<Text>().color = Color.black;
                    orderListMovieTicket.transform.GetChild(0).gameObject.SetActive(true); // Display green checkmark
                    TicketInteract.isHoldingTicket = false;
                    ticketHold.SetActive(false);
                    return;
                }
                // Ticket failure
                failureAudio.Play();
                // We don't need to set the color to red for order failues w/ movie ticket
                return;
            }

            // If player has nothing to serve the customer, then play the original dialogue:
            // This method will always fire the first time the NPC walks up to the register.

            // Customer #1 order:
            if (!LevelSixEventManager.boolTrig) { 
                order = new CustomerOrder() {
                    MovieTicket = MovieTicketOrder,
                    Popcorn = PopcornOrder,
                    Drink = DrinkOrder
                };
                customerOrderStarted = true;
                CustomerOnEnter.isCustomerActive = false;
                defaultCircle.color = new Color(255, 255, 255, 145);
                hoverText.text = "";
                dialoguePanelName.text = npcName + ":";
                DialogueManager.GetInstance(cameraToActivate, player).EnterDialogueMode(customerInkJson);
            }
        }
    }

    private void OnMouseExit()
    {
        if (CustomerOnEnter.isCustomerActive && RegisterTarget.hasEnteredCollider)
        {
            defaultCircle.color = new Color(255, 255, 255, 145);
            hoverText.text = "";
        }
    }

    private void OnMouseOver()
    {
        if (CustomerOnEnter.isCustomerActive && RegisterTarget.hasEnteredCollider)
        {
            defaultCircle.color = Color.red;
            hoverText.text = npcName;
        }
    }
}
