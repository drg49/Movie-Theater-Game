using UnityEngine;

public class DerekExitCounter : MonoBehaviour
{
    [SerializeField] private Animator animController;
    public GameObject leftTurnAroundTrigger;
    private void OnTriggerEnter(Collider other)
    {
        if (animController.GetBool("TriggerLeftTurn180"))
        {
            animController.SetBool("TriggerLeftTurn180", false);
            leftTurnAroundTrigger.GetComponent<BoxCollider>().enabled = true;
            animController.SetBool("TriggerRightTurn180", true);
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
