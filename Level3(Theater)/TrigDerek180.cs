using UnityEngine;

public class TrigDerek180 : MonoBehaviour
{
    [SerializeField] private Animator animController;
    public GameObject exitCounterTrigger;

    private void OnTriggerEnter()
    {
        animController.SetBool("TriggerLeftTurn180", true);
        gameObject.GetComponent<BoxCollider>().enabled = false;
        animController.SetBool("TriggerRightTurn180", false);
        exitCounterTrigger.GetComponent<BoxCollider>().enabled = true;
    }
}
