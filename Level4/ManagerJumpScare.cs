using UnityEngine;
using UnityEngine.UI;

public class ManagerJumpScare : MonoBehaviour
{
    public GameObject manager;
    public AudioSource jumpScareAudio;
    public GameObject cameraToActivate;
    public GameObject player;
    [SerializeField] private TextAsset inkJSON;
    public Text dialoguePanelName;
    public string npcName;
    public GameObject managerOnEnter;
    public Text menuObjTwo;
    public Text menuObjThree;

    // Activate these next events after 'manager jump scare' finishes
    public GameObject kate;
    public GameObject kateOnEnter;
    public GameObject removerManagerTrig;
    public GameObject houseDoorInteract;

    public static bool objThreeReady = false;

    private void OnTriggerEnter()
    {
        gameObject.SetActive(false);
        manager.SetActive(true);
        jumpScareAudio.Play();
        dialoguePanelName.text = npcName + ":";
        DialogueManager.GetInstance(cameraToActivate, player).EnterDialogueMode(inkJSON);
        managerOnEnter.SetActive(true);
        menuObjTwo.color = Color.gray;
        menuObjThree.color = new Color(255, 255, 255, 255);
        objThreeReady = true;
        kate.SetActive(true);
        kateOnEnter.SetActive(true);
        removerManagerTrig.SetActive(true);
        houseDoorInteract.SetActive(true);
    }
}
