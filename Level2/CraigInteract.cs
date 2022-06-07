using UnityEngine;
using UnityEngine.UI;

public class CraigInteract : MonoBehaviour
{
    [SerializeField] private TextAsset inkJSON;
    public GameObject cameraToActivate;
    public GameObject player;
    public Image defaultCircle;
    public Text dialoguePanelName;
    public Text hoverText;
    public string npcName;

    private void OnMouseDown()
    {
        if(CraigOnEnter.isCraigActive && !PauseMenu.GameIsPaused)
        {
            CraigOnEnter.isCraigActive = false;
            defaultCircle.color = new Color(255, 255, 255, 145);
            hoverText.text = "";
            dialoguePanelName.text = npcName + ":";
            DialogueManager.GetInstance(cameraToActivate, player).EnterDialogueMode(inkJSON);
        }
    }

    private void OnMouseExit()
    {
        if (CraigOnEnter.isCraigActive)
        {
            defaultCircle.color = new Color(255, 255, 255, 145);
            hoverText.text = "";
        }
    }

    private void OnMouseOver()
    {
        if (CraigOnEnter.isCraigActive)
        {
            defaultCircle.color = Color.red;
            hoverText.text = npcName;
        }
    }
}
