using UnityEngine;
using UnityEngine.AI;

public class Cust02Self : MonoBehaviour
{
    private static bool isPlaying = false;
    void Update()
    {
        if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Walk To Register") && !isPlaying)
        {
            Rigidbody newRb = gameObject.AddComponent<Rigidbody>();
            newRb.constraints = RigidbodyConstraints.FreezeAll;
            gameObject.GetComponent<NavMeshAgent>().enabled = true;
            gameObject.GetComponent<NpcNavMesh>().enabled = true;
            isPlaying = true;
        }
    }
}
