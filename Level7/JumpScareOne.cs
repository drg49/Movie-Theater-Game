using UnityEngine;
using UnityEngine.UI;

public class JumpScareOne : MonoBehaviour
{
    public GameObject magician;
    public GameObject cameraToActivate;
    public GameObject player;
    public GameObject fpsHands;
    public Text dialoguePanelName;
    public AudioSource jumpScareAudio;
    [SerializeField] private TextAsset inkJSON;
    public string npcName;

    public bool hasTalkedToMagician = false;

    private void OnTriggerEnter()
    {
        gameObject.SetActive(false);
        if (fpsHands.activeSelf)
        {
            fpsHands.GetComponent<HandgunControls>().PutGunAway();
            fpsHands.GetComponent<HandgunControls>().gunIsOut = true;
        }
        magician.SetActive(true);
        jumpScareAudio.Play();
        dialoguePanelName.text = npcName + ":";
        DialogueManager.GetInstance(cameraToActivate, player).EnterDialogueMode(inkJSON);
        hasTalkedToMagician = true;
    }
}
