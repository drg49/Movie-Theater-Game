using UnityEngine;

public class TriggerLeftTurn : MonoBehaviour
{
    [SerializeField] private Animator animController;

    private void OnTriggerEnter()
    {
        animController.SetBool("TriggerLeftTurn", true);
    }
}
