using UnityEngine;
using UnityEngine.AI;

// A basic script to move an NPC to its provided target

public class MoveNpc : MonoBehaviour
{
    public Transform movePositionTransform;
    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        navMeshAgent.destination = movePositionTransform.position;
    }
}
