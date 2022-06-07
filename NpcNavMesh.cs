using UnityEngine;
using UnityEngine.AI;

public class NpcNavMesh : MonoBehaviour
{
    public Transform movePositionTransform;
    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (TriggerLeaveAnim.meActive || LevelManager.isLevelSix)
        {
            navMeshAgent.destination = movePositionTransform.position;
        }
    }
}
