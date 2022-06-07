using UnityEngine;

public class TriggerLeaveAnim : StateMachineBehaviour
{
    public static bool meActive = false;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        meActive = true;
    }
}
