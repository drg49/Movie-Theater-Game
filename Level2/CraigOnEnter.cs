using UnityEngine;
using UnityEngine.UI;

public class CraigOnEnter : MonoBehaviour
{
    public static bool isCraigActive = false;
    public Image defaultCircle;
    public Text hoverText;

    private void OnTriggerEnter()
    {
        isCraigActive = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isCraigActive = false;
        defaultCircle.color = new Color(255, 255, 255, 145);
        hoverText.text = "";
    }
}
