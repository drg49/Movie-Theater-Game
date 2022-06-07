using UnityEngine;
using UnityEngine.UI;

public class DerekLeave : MonoBehaviour
{
    public static bool beginScript = false;
    public Image sceneFade;
    public GameObject counterTrap;
    [SerializeField] private Animator derekAnim;

    // DEREK NEW STATE: 
    public GameObject DerekClone;

    public Animator objectiveTwo;

    public Text menuObjectiveOne;
    public Text menuObjectiveTwo;

    // For Level Six:
    public GameObject npc09;

    private void TriggerDerekLeaving()
    {
        GameObject[] originalDerekObjects = GameObject.FindGameObjectsWithTag("Derek");
        foreach (GameObject target in originalDerekObjects)
        {
            Destroy(target);
        }
        if (LevelManager.isLevelSix)
        {
            npc09.SetActive(true);
        }
        else
        {
            counterTrap.SetActive(true);
            DerekClone.SetActive(true);
            derekAnim.SetTrigger("TriggerDerekExit");
        }
    }

    private void Update()
    {
        if (beginScript && sceneFade.color.a >= 0.90)
        {
            TriggerDerekLeaving();
            menuObjectiveOne.color = Color.gray;
            if (LevelManager.isLevelSix == false)
            {
                objectiveTwo.SetBool("TriggerFadeIn", true);
                menuObjectiveTwo.color = new Color(255, 255, 255, 255);
            }
            beginScript = false;
        }
    }
}
