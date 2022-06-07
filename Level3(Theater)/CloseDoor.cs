using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    [SerializeField] private Animator doorAnim;
    public GameObject gameObjToDestroy;

    private void OnTriggerEnter()
    {
        doorAnim.SetTrigger("CloseDoor");
        LevelThreeEventManager.eventOne = true;
        Destroy(gameObjToDestroy);
    }
}
