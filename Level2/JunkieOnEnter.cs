using UnityEngine;
using UnityEngine.UI;

public class JunkieOnEnter : MonoBehaviour
{
    public static bool isJunkieActive = false;
    public Image defaultCircle;
    public Text hoverText;

    private void OnTriggerEnter(Collider player)
    {
        if (player.tag == "Player")
        {
            isJunkieActive = true;
        }
    }

    private void OnTriggerExit(Collider player)
    {
        if (player.tag == "Player")
        {
            isJunkieActive = false;
            defaultCircle.color = new Color(255, 255, 255, 145);
            hoverText.text = "";
        }
    }
}
