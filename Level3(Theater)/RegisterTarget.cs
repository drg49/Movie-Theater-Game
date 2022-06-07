using UnityEngine;
using UnityEngine.AI;

public class RegisterTarget : MonoBehaviour
{
    public GameObject customerOne;
    public static bool hasEnteredCollider = false;

    public GameObject customerTwo;
    public GameObject customerThree;
    public GameObject npcNine;
    public GameObject magician;

    public GameObject customerOnEnter;
    public GameObject trigCounterTrap;

    // When Customer One approaches the register:
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "Cust01")
        {
            hasEnteredCollider = true;
            customerOne.GetComponent<RotateToTarget>().enabled = true;
            customerOne.GetComponent<NpcNavMesh>().enabled = false;
            customerOne.GetComponent<NavMeshAgent>().enabled = false;
            customerOne.GetComponent<Animator>().SetTrigger("Idle");
        }
        else if (collider.name == "Cust02")
        {
            hasEnteredCollider = true;
            customerOnEnter.SetActive(true);
            customerTwo.GetComponent<RotateToTarget>().enabled = true;
            customerTwo.GetComponent<NpcNavMesh>().enabled = false;
            customerTwo.GetComponent<NavMeshAgent>().enabled = false;
            customerTwo.GetComponent<Animator>().SetTrigger("Idle");
        }
        else if (collider.name == "Cust03")
        {
            hasEnteredCollider = true;
            CustomerOnEnter.isCustomerActive = true;
            customerOnEnter.SetActive(true);
            customerThree.GetComponent<RotateToTarget>().enabled = true;
            customerThree.GetComponent<NpcNavMesh>().enabled = false;
            customerThree.GetComponent<NavMeshAgent>().enabled = false;
            customerThree.GetComponent<Animator>().SetTrigger("Idle");
        }
        else if (collider.name == "Npc09")
        {
            hasEnteredCollider = true;
            if (trigCounterTrap != null)
            {
                trigCounterTrap.SetActive(true);
            }
            customerOnEnter.SetActive(true);
            npcNine.GetComponent<CapsuleCollider>().isTrigger = false;
            npcNine.GetComponent<RotateToTarget>().enabled = true;
            npcNine.GetComponent<NpcNavMesh>().enabled = false;
            npcNine.GetComponent<NavMeshAgent>().enabled = false;
            npcNine.GetComponent<Animator>().SetTrigger("Idle");
        }
        else if (collider.name == "Magician")
        {
            hasEnteredCollider = true;
            customerOnEnter.SetActive(true);
            magician.GetComponent<RotateToTarget>().enabled = true;
            magician.GetComponent<NpcNavMesh>().enabled = false;
            magician.GetComponent<NavMeshAgent>().enabled = false;
            magician.GetComponent<Animator>().SetTrigger("Idle");
        }
    }
}
