using UnityEngine;
using UnityEngine.UI;

public class ObjectiveOne : MonoBehaviour
{
    [SerializeField] private Animator myAnimationController;
    public Text objectiveOne;

    private void OnTriggerEnter()
    {
        myAnimationController.SetBool("TriggerFadeIn", true);
        objectiveOne.color = new Color(255, 255, 255, 255);
        Destroy(gameObject);
    }
}
