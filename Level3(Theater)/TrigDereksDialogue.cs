using UnityEngine;
using UnityEngine.UI;

public class TrigDereksDialogue : MonoBehaviour
{
    [SerializeField] private TextAsset inkJSON;
    public GameObject cameraToActivate;
    public GameObject player;
    public Text dialoguePanelName;
    public string npcName;
    public GameObject obj1;
    public GameObject movieItemsOnEnter;

    private void OnTriggerEnter()
    {
        Destroy(obj1);
        gameObject.SetActive(false);
        dialoguePanelName.text = npcName + ":";
        DialogueManager.GetInstance(cameraToActivate, player).EnterDialogueMode(inkJSON);
        movieItemsOnEnter.SetActive(true);
    }
}
