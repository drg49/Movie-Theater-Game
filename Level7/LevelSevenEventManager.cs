using UnityEngine;

public class LevelSevenEventManager : MonoBehaviour
{
    public GameObject fpsController;
    public GameObject objectiveOne;
    public GameObject jumpScareOne;
    public GameObject fpsHands;
    public GameObject defaultCircle;
    public GameObject pistolCrosshair;
    public GameObject magician;
    public GameObject objOne;
    public Animator objTwo;
    public GameObject menuObjTwo;
    private bool eventOneFired = false;
    private bool eventTwoFired = false;

    private void Update()
    {
        if (fpsController.activeSelf && !eventOneFired)
        {
            Invoke("ShowObjectiveOne", 0.7f);
            eventOneFired = true;
        }
        if (jumpScareOne != null)
        {
            if (fpsController.activeSelf && jumpScareOne.GetComponent<JumpScareOne>().hasTalkedToMagician && !eventTwoFired)
            {
                Destroy(magician);
                Destroy(objOne);
                if (fpsHands.activeSelf)
                {
                    defaultCircle.SetActive(false);
                    pistolCrosshair.SetActive(true);
                }
                Destroy(jumpScareOne);
                menuObjTwo.SetActive(true);
                objTwo.SetBool("TriggerFadeIn", true);
                Debug.Log("Now time to find  6 tapes");
                eventTwoFired = true;
            }
        }
    }

    private void ShowObjectiveOne()
    {
        objectiveOne.SetActive(true);
    }
}
