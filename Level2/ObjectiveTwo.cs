using UnityEngine;
using UnityEngine.UI;

public class ObjectiveTwo : MonoBehaviour
{
    [SerializeField] private Animator myAnimationController;
    public Text objectiveOne;
    public Text objectiveTwo;

    private void OnTriggerEnter()
    {
        myAnimationController.SetBool("TriggerFadeIn", true);
        objectiveOne.color = Color.gray;
        objectiveTwo.color = new Color(255, 255, 255, 255);
        Destroy(gameObject);
    }
}
