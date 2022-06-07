using UnityEngine;
using UnityEngine.UI;

public class ClockInInteract : MonoBehaviour
{
    public GameObject defaultCircle;
    public Material timesheetSuccessScreen;
    public AudioSource computerSuccessAudio;
    public Text hoverText;
    public string objectName;
    [SerializeField] private Animator sceneFadeAnimController;
    public Text objectiveOne;

    private void OnMouseDown()
    {
        if (ClockInOnEnter.isComputerActive && !PauseMenu.GameIsPaused)
        {
            hoverText.text = "";
            objectiveOne.color = Color.gray;
            defaultCircle.GetComponent<ToggleCrosshair>().SetDefault();
            gameObject.GetComponent<MeshRenderer>().material = timesheetSuccessScreen;
            computerSuccessAudio.Play();
            gameObject.GetComponent<BoxCollider>().enabled = false;
            sceneFadeAnimController.SetTrigger("ExitTrigger");
            DerekLeave.beginScript = true;
        }
    }

    private void OnMouseOver()
    {
        if (ClockInOnEnter.isComputerActive)
        {
            hoverText.text = objectName;
            defaultCircle.GetComponent<ToggleCrosshair>().SetHandGrab();
        }
    }

    private void OnMouseExit()
    {
        if (ClockInOnEnter.isComputerActive)
        {
            hoverText.text = "";
            defaultCircle.GetComponent<ToggleCrosshair>().SetDefault();
        }
    }
}
