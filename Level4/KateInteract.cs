using UnityEngine;
using UnityEngine.UI;

public class KateInteract : MonoBehaviour
{
    public Image defaultCircle;
    public UniversalOnEnter childOnEnter;
    public Text hoverText;
    public GameObject cameraToActivate;
    public GameObject player;
    [SerializeField] private TextAsset inkJSON;
    public Text dialoguePanelName;

    private void OnMouseDown()
    {
        if (childOnEnter.isActive && !PauseMenu.GameIsPaused)
        {
            childOnEnter.isActive = false;
            defaultCircle.color = new Color(255, 255, 255, 145);
            hoverText.text = "";
            dialoguePanelName.text = gameObject.name + ":";
            DialogueManager.GetInstance(cameraToActivate, player).EnterDialogueMode(inkJSON);
        }
    }

    private void OnMouseOver()
    {
        if (childOnEnter.isActive)
        {
            defaultCircle.color = Color.red;
            hoverText.text = gameObject.name;
        }
    }

    private void OnMouseExit()
    {
        if (childOnEnter.isActive)
        {
            defaultCircle.color = new Color(255, 255, 255, 145);
            hoverText.text = "";
        }
    }
}
