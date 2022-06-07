using UnityEngine;
using UnityEngine.UI;

public class MagicianInteract : MonoBehaviour
{
    public GameObject cameraToActivate;
    public GameObject player;
    [SerializeField] private TextAsset inkJSON;
    public Image defaultCircle;
    public Text hoverText;
    public Text dialoguePanelName;
    public string npcName;

    public static bool hasTalkedToMagician = false;

    private void OnMouseDown()
    {
        if (CustomerOnEnter.isCustomerActive && RegisterTarget.hasEnteredCollider && !PauseMenu.GameIsPaused && MagicianDialogueEvent.readyToTalkToMagician)
        {
            CustomerOnEnter.isCustomerActive = false;
            dialoguePanelName.text = npcName + ":";
            defaultCircle.color = new Color(255, 255, 255, 145);
            hoverText.text = "";
            DialogueManager.GetInstance(cameraToActivate, player).EnterDialogueMode(inkJSON);
            MagicianDialogueEvent.readyToTalkToMagician = false;
            hasTalkedToMagician = true;
        }
    }

    private void OnMouseOver()
    {
        if (CustomerOnEnter.isCustomerActive && RegisterTarget.hasEnteredCollider && MagicianDialogueEvent.readyToTalkToMagician)
        {
            defaultCircle.color = Color.red;
            hoverText.text = npcName;
        }
    }

    private void OnMouseExit()
    {
        if (CustomerOnEnter.isCustomerActive && RegisterTarget.hasEnteredCollider && MagicianDialogueEvent.readyToTalkToMagician)
        {
            defaultCircle.color = new Color(255, 255, 255, 145);
            hoverText.text = "";
        }
    }
}
