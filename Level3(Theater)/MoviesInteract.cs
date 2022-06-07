using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MoviesInteract : MonoBehaviour
{
    public ToggleCrosshair defaultCircle;
    public Text hoverText;
    public Text instructionalText;

    public GameObject derekCamera;

    // The cups that the player will hold
    public GameObject smallCup;
    public GameObject largeCup;

    public GameObject smallCupLid;
    public GameObject largeCupLid;

    // The bags of popcorn that a player will hold
    public GameObject smallPopcorn;
    public GameObject largePopcorn;

    public static bool playerIsHoldingACup = false;
    public static bool playerIsHoldingPopcorn = false;

    // Sound that is played every time player interacts with items on counter
    public AudioSource interactSound;

    public static CustomerOrder playerOrder = new CustomerOrder(); // When finalizing the order, compare this List to CustomerInteract.order

    public List<string> typesOfSoda = new List<string>() { "Diet Fresh Cola", "Fresh Cola", "Clear Water", "Fizzy Water", "Fresh Cola Zero", "Best Zero" };
    private static ParticleSystem fountainParticles;
    private static bool isSodaParticlesPlaying = false;

    public static bool isMouseDisabled = false;

    public GameObject orderTicket;
    public static bool custEvent = false;

    public GameObject FpsController;
    public List<GameObject> fountainCupLarge;
    public List<GameObject> fountainCupSmall;

    public static bool drinkReadyToServe = false;

    private void Update()
    {
        if (CustomerInteract.customerOrderStarted && FpsController.activeSelf)
        {
            if (!custEvent && !LevelSixEventManager.boolTrig)
            {
                orderTicket.SetActive(true); // Display items on order ticket
                orderTicket.transform.GetChild(1).gameObject.GetComponent<Text>().text = CustomerInteract.order.MovieTicket ? "Movie Ticket" : "";
                orderTicket.transform.GetChild(2).gameObject.GetComponent<Text>().text = CustomerInteract.order.Popcorn;
                orderTicket.transform.GetChild(3).gameObject.GetComponent<Text>().text = CustomerInteract.order.Drink;
                custEvent = true;
            }
        }
        if (interactSound.name == "SodaFountainAudio" && interactSound.isPlaying)
        {
            isMouseDisabled = true;
            if (!isSodaParticlesPlaying) // When soda begins to fill cup
            {
                fountainParticles.Play();
                isSodaParticlesPlaying = true;
            }
        }
        else
        {
            if (isSodaParticlesPlaying) // When soda is done being filled
            {
                drinkReadyToServe = true;
                if (fountainCupLarge.Any(largeFountainCup => largeFountainCup.activeSelf))
                {
                    foreach(GameObject cup in fountainCupLarge)
                    {
                        if (cup.activeSelf)
                        {
                            cup.SetActive(false); // Cup on fountain disappears
                        }
                    }
                    largeCupLid.SetActive(true); // Cup in hand appears
                }
                if (fountainCupSmall.Any(smallFountainCup => smallFountainCup.activeSelf))
                {
                    foreach (GameObject cup in fountainCupSmall)
                    {
                        if (cup.activeSelf)
                        {
                            cup.SetActive(false); // Cup on fountain disappears
                        }
                    }
                    smallCupLid.SetActive(true); // Cup in hand appears
                }
                fountainParticles.Stop();
                isSodaParticlesPlaying = false;
            }
            isMouseDisabled = false;
        }
    }
    private void OnMouseDown()
    {
        if (!isMouseDisabled && !PauseMenu.GameIsPaused)
        {
            // GRAB SMALL CUPS / LARGE CUPS
            if (MovieItemsOnEnter.isActive && CustomerInteract.customerOrderStarted && gameObject.name == "Small Cups")
            {
                if (playerIsHoldingPopcorn || drinkReadyToServe || TicketInteract.isHoldingTicket)
                {
                    instructionalText.text = "Trash the item or hand it to the customer before continuing.";
                    Invoke("clearInstructionalText", 4);
                }
                else // Grab cup if hands are free
                {
                    playerIsHoldingACup = true;
                    defaultCircle.SetDefault();
                    hoverText.text = "";
                    smallCup.SetActive(true); // Activate Small Cup
                    largeCup.SetActive(false); // Deactivate Large Cup
                }
            }
            else if (MovieItemsOnEnter.isActive && CustomerInteract.customerOrderStarted && gameObject.name == "Large Cups")
            {
                if (playerIsHoldingPopcorn || drinkReadyToServe || TicketInteract.isHoldingTicket)
                {
                    instructionalText.text = "Trash the item or hand it to the customer before continuing.";
                    Invoke("clearInstructionalText", 4);
                }
                else // Grab cup if hands are free
                {
                    playerIsHoldingACup = true;
                    defaultCircle.SetDefault();
                    hoverText.text = "";
                    largeCup.SetActive(true); // Activate Large Cup
                    smallCup.SetActive(false); // Deactivate Small Cup
                }
            }

            // GRAB POPCORN
            else if (MovieItemsOnEnter.isActive && CustomerInteract.customerOrderStarted && gameObject.name == "Small Popcorn")
            {
                if (playerIsHoldingACup || TicketInteract.isHoldingTicket)
                {
                    instructionalText.text = "Trash the item or hand it to the customer before continuing.";
                    Invoke("clearInstructionalText", 4);
                }
                else // Grab popcorn if hands are free
                {
                    playerIsHoldingPopcorn = true;
                    defaultCircle.SetDefault();
                    hoverText.text = "";
                    smallPopcorn.SetActive(true);
                    largePopcorn.SetActive(false);
                    playerOrder.Popcorn = gameObject.name;
                }
            }
            else if (MovieItemsOnEnter.isActive && CustomerInteract.customerOrderStarted && gameObject.name == "Large Popcorn")
            {
                if (playerIsHoldingACup || TicketInteract.isHoldingTicket)
                {
                    instructionalText.text = "Trash the item or hand it to the customer before continuing.";
                    Invoke("clearInstructionalText", 4);
                }
                else // Grab popcorn if hands are free
                {
                    playerIsHoldingPopcorn = true;
                    defaultCircle.SetDefault();
                    hoverText.text = "";
                    largePopcorn.SetActive(true);
                    smallPopcorn.SetActive(false);
                    playerOrder.Popcorn = gameObject.name;
                }
            }

            // Else If player selects a soda
            else if (MovieItemsOnEnter.isActive && CustomerInteract.customerOrderStarted && typesOfSoda.Contains(gameObject.name))
            {
                if (drinkReadyToServe || TicketInteract.isHoldingTicket)
                {
                    instructionalText.text = "Trash the item or hand it to the customer before continuing.";
                    Invoke("clearInstructionalText", 4);
                }
                else
                {
                    chooseSodaFlavor(playerIsHoldingACup);
                }
            }
        }
    }

    private void chooseSodaFlavor(bool playerIsHoldingACup)
    {
        GameObject fountainTarget = gameObject.transform.GetChild(0).gameObject;
        defaultCircle.SetDefault();
        hoverText.text = "";
        if (playerIsHoldingACup)
        {
            if (largeCup.activeSelf)
            {
                playerOrder.Drink = "Large " + gameObject.name;
                gameObject.transform.GetChild(0).gameObject.SetActive(true); // Set large cup on fountain to be active
                largeCup.SetActive(false); // Remove large cup in hand
                fountainParticles = gameObject.transform.GetChild(2).gameObject.GetComponent<ParticleSystem>();
                interactSound.Play();
            }
            else if(smallCup.activeSelf)
            {
                playerOrder.Drink = "Small " + gameObject.name;
                gameObject.transform.GetChild(1).gameObject.SetActive(true); // Set small cup on fountain to be active
                smallCup.SetActive(false); // Remove small cup in hand
                fountainParticles = gameObject.transform.GetChild(2).gameObject.GetComponent<ParticleSystem>();
                interactSound.Play();
            }
        }
        else
        {
            instructionalText.text = "You must grab a cup first.";
            Invoke("clearInstructionalText", 4);
        }
    }

    private void OnMouseOver()
    {
        if (MovieItemsOnEnter.isActive && !derekCamera.activeSelf)
        {
            defaultCircle.SetHandGrab();
            hoverText.text = gameObject.name;
        }
    }

    private void OnMouseExit()
    {
        if (MovieItemsOnEnter.isActive && !derekCamera.activeSelf)
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
