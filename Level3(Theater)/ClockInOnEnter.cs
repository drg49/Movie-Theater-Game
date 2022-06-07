using UnityEngine;
using UnityEngine.UI;

public class ClockInOnEnter : MonoBehaviour
{
    public GameObject defaultCircle;
    public static bool isComputerActive = false;
    public Text hoverText;

    private void OnTriggerEnter()
    {
        isComputerActive = true;
    }

    private void OnTriggerExit()
    {
        isComputerActive = false;
        hoverText.text = "";
        defaultCircle.GetComponent<ToggleCrosshair>().SetDefault();
    }
}
