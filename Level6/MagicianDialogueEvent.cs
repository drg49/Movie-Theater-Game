using UnityEngine;
using UnityEngine.AI;

public class MagicianDialogueEvent : MonoBehaviour
{
    public GameObject magician;
    public Transform registerTarget;
    private bool stopUpdate = false;

    public static bool readyToTalkToMagician = false;

    void Update()
    {
        if (magician.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Idle Two") && !stopUpdate)
        {
            Invoke("MoveMagicianToRegister", 3);
            stopUpdate = true;
        }    
    }

    private void MoveMagicianToRegister()
    {
        magician.GetComponent<Animator>().SetTrigger("Walking");
        magician.GetComponent<NpcNavMesh>().enabled = true;
        magician.GetComponent<NavMeshAgent>().enabled = true;
        magician.GetComponent<NpcNavMesh>().movePositionTransform = registerTarget;
        readyToTalkToMagician = true;
    }
}
