using UnityEngine;
using UnityEngine.UI;

public class JunkieInteract : MonoBehaviour
{
    [SerializeField] private TextAsset inkJSON;
    public Image defaultCircle;
    public Text hoverText;
    public GameObject player;
    public GameObject cameraToSwitch;
    public Text dialoguePanelName;
    public string npcName;

    private void OnMouseDown()
    {
        if (JunkieOnEnter.isJunkieActive && !PauseMenu.GameIsPaused)
        {
            JunkieOnEnter.isJunkieActive = false;
            defaultCircle.color = new Color(255, 255, 255, 145);
            hoverText.text = "";
            dialoguePanelName.text = npcName + ":";
            DialogueManager.GetInstance(cameraToSwitch, player).EnterDialogueMode(inkJSON);
        }
    }

    private void OnMouseExit()
    {
        if (JunkieOnEnter.isJunkieActive)
        {
            defaultCircle.color = new Color(255, 255, 255, 145);
            hoverText.text = "";
        }
    }

    private void OnMouseOver()
    {
        if (JunkieOnEnter.isJunkieActive)
        {
            defaultCircle.color = Color.red;
            hoverText.text = npcName;
        }
    }
}
