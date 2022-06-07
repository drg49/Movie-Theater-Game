using UnityEngine;

public class StopWalkingAnim : MonoBehaviour
{
    [SerializeField] private Animator derekAnim;
    [SerializeField] private Animator doorAnim;
    private void OnTriggerEnter(Collider gameObject)
    {
        if (gameObject.name == "DerekClone")
        {
            derekAnim.SetTrigger("OpenDoorTrigger");
            doorAnim.SetTrigger("OpenDoor");
        }
    }
}
