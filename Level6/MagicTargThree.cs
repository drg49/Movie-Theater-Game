using UnityEngine;
using UnityEngine.AI;

public class MagicTargThree : MonoBehaviour
{
    public GameObject magician;
    public Transform theaterScreen;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "Magician")
        {
            magician.GetComponent<CapsuleCollider>().isTrigger = false;
            magician.GetComponent<RotateToTarget>().target = theaterScreen;
            magician.GetComponent<RotateToTarget>().enabled = true;
            magician.GetComponent<NpcNavMesh>().enabled = false;
            magician.GetComponent<NavMeshAgent>().enabled = false;
            magician.GetComponent<Animator>().SetTrigger("IdleAgain");
        }
    }
}
