using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelThreeEventManager : MonoBehaviour
{
    [SerializeField] private Animator doorAnim;
    [SerializeField] private Animator sceneFadeAnim;

    public GameObject counterTrap;

    // Derek has already left the theater, first customer is ready to appear through the door.
    public static bool eventOne = false;

    // Customer three will walk through the door.
    public static bool eventTwo = false;

    // Time to cleanup trash in theater
    public static bool eventThree = false;

    // Trash has been picked up, time to move onto level four
    public static bool eventFour = false;

    // Finished customer one's order completely
    public static bool custOneEvent = false;

    // Finished customer two's order completely
    public static bool custTwoEvent = false;

    // Finished customer threes order completely
    public static bool customerThreeEvent = false;

    public GameObject customerOne;
    public GameObject customerTwo;
    public GameObject customerThree;

    // Transform target that guides NPCs into the movie theater
    public Transform intoTheaterTarget;

    public GameObject OrderListUI;
    public List<Text> OrderItems;

    public Image defaultCircle;
    public Text hoverText;

    public Text menuObj2;
    public Text menuObj3;
    public Animator objThree;

    public GameObject trashBagOnEnter;
    public GameObject trashBag;
    public List<GameObject> theaterTrash;

    public string outsideLevel;

    private void Update()
    {
        if (eventOne)
        {
            Invoke("LoadFirstCustomer", 16);
            eventOne = false;
        }
        if (eventTwo)
        {
            Invoke("LoadThirdCustomer", 8);
            eventTwo = false;
        }
        if (eventThree)
        {
            counterTrap.SetActive(false);
            objThree.SetBool("TriggerFadeIn", true);
            menuObj2.color = Color.gray;
            menuObj3.color = new Color(255, 255, 255, 255);
            trashBagOnEnter.SetActive(true);
            trashBag.SetActive(true);
            foreach(GameObject trash in theaterTrash)
            {
                trash.SetActive(true);
            }
            eventThree = false;
        }
        if (TrashRatio.trashPickedUp == 5 && !eventFour)
        {
            Invoke("TriggerFadeIn", 1);
        }
        if (CustomerInteract.custDrinkFulfilled && CustomerInteract.custPopcornFulfilled && CustomerInteract.custTicketFulfilled && !custOneEvent)
        {
            ResetValues();
            customerOne.GetComponent<RotateToTarget>().enabled = false;
            customerOne.GetComponent<NavMeshAgent>().enabled = true;
            customerOne.GetComponent<NpcNavMesh>().enabled = true;
            customerOne.GetComponent<NpcNavMesh>().movePositionTransform = intoTheaterTarget;
            customerOne.GetComponent<Animator>().SetTrigger("WalkAgain");
            custOneEvent = true;
        }
        else if (CustomerInteract.custDrinkFulfilled && !custTwoEvent && custOneEvent)
        {
            ResetValues();
            customerTwo.GetComponent<RotateToTarget>().enabled = false;
            customerTwo.GetComponent<NavMeshAgent>().enabled = true;
            customerTwo.GetComponent<NavMeshAgent>().speed = 2.4f;
            customerTwo.GetComponent<NpcNavMesh>().enabled = true;
            customerTwo.GetComponent<NpcNavMesh>().movePositionTransform = intoTheaterTarget;
            customerTwo.GetComponent<Animator>().SetTrigger("WalkAgain");
            custTwoEvent = true;
        }
        else if (CustomerInteract.custDrinkFulfilled && CustomerInteract.custPopcornFulfilled && CustomerInteract.custTicketFulfilled && !customerThreeEvent && custTwoEvent && custOneEvent)
        {
            ResetValues();
            customerThree.GetComponent<RotateToTarget>().enabled = false;
            customerThree.GetComponent<NavMeshAgent>().enabled = true;
            customerThree.GetComponent<NpcNavMesh>().enabled = true;
            customerThree.GetComponent<NpcNavMesh>().movePositionTransform = intoTheaterTarget;
            customerThree.GetComponent<Animator>().SetTrigger("WalkAgain");
            Invoke("ThreeHoursLater", 6);
            customerThreeEvent = true;
        }
    }

    private void LoadFirstCustomer()
    {
        MovieTheaterDoor.eventOne = true;
        doorAnim.SetTrigger("OpenDoor");
    }

    private void LoadThirdCustomer()
    {
        MovieTheaterDoor.eventTwo = true;
        doorAnim.SetTrigger("OpenDoor");
    }

    public void ThreeHoursLater()
    {
        sceneFadeAnim.SetTrigger("ThreeHoursLater");
    }

    private void MoveOntoLvlFour()
    {
        LevelManager.isLevelFour = true;
        SceneManager.LoadScene(outsideLevel);
    }

    private void TriggerFadeIn()
    {
        sceneFadeAnim.SetBool("ExitTrigger", true);
        Invoke("MoveOntoLvlFour", 1.4f);
    }

    private void ResetValues()
    {
        // Reset the order event so the next customer can start their order
        CustomerInteract.customerOrderStarted = false;
        CustomerInteract.custDrinkFulfilled = false;
        CustomerInteract.custPopcornFulfilled = false;
        CustomerInteract.custTicketFulfilled = false;

        RegisterTarget.hasEnteredCollider = false;
        CustomerOnEnter.isCustomerActive = false;

        defaultCircle.color = new Color(255, 255, 255, 145);
        hoverText.text = "";

        OrderListUI.SetActive(false);
        foreach (Text item in OrderItems) // Reset the text for order list UI
        {
            item.text = "";
            item.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
