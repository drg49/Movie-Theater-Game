using UnityEngine;
using UnityEngine.UI;

public class HideMagicianTrigger : MonoBehaviour
{
    public string objectiveTwoText;
    public GameObject magician;
    public Text menuObjOne;
    public Text menuObjTwo;
    public GameObject objectiveTwo;

    private void OnTriggerEnter()
    {
        Destroy(magician);
        menuObjOne.color = Color.gray;
        menuObjTwo.text = objectiveTwoText;
        menuObjTwo.color = new Color(255, 255, 255, 255);
        objectiveTwo.GetComponent<Text>().text = objectiveTwoText;
        objectiveTwo.GetComponent<Animator>().SetBool("TriggerFadeIn", true);
        Destroy(gameObject);
    }
}
