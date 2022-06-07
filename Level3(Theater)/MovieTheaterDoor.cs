using UnityEngine;
using UnityEngine.AI;

public class MovieTheaterDoor : MonoBehaviour
{
    public GameObject npcToDisable;

    public GameObject customerOne;
    public GameObject customerThree;

    public AudioSource doorOpenSound;
    public AudioSource doorCloseSound;

    //EVENTS
    public static bool eventOne;
    public static bool eventTwo;

    // This method is an event triggered at the end of the DoorOpen animation
    public void MoveCharacterOutDoor()
    {
        if (npcToDisable != null)
        {
            npcToDisable.GetComponent<NpcNavMesh>().enabled = false;
            npcToDisable.GetComponent<NavMeshAgent>().enabled = false;
        }
        MoveObjectTowards.startMovement = true;
    }

    //This function is set as an event on the Movie Theater DoorOpen Animation
    public void LoadCustomer()
    {
        if (eventOne) // First customer appears at the door
        {
            customerOne.SetActive(true);
            Invoke("CloseDoorAnim", 1);
            eventOne = false;
        }
        if (eventTwo) // Third customer appears at the door
        {
            customerThree.SetActive(true);
            Invoke("CloseDoorAnim", 1);
            eventTwo = false;
        }
    }

    public void DoorOpenSound()
    {
        doorOpenSound.Play();
    }

    public void DoorCloseSound()
    {
        doorCloseSound.Play();
    }

    public void CloseDoorAnim()
    {
        gameObject.GetComponent<Animator>().SetTrigger("CloseDoor");
    }

}
