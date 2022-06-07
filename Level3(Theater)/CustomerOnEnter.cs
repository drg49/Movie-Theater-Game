using UnityEngine;
using UnityEngine.UI;

public class CustomerOnEnter : MonoBehaviour
{
    public static bool isCustomerActive = false;
    public Image defaultCircle;
    public Text hoverText;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            isCustomerActive = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            isCustomerActive = false;
            defaultCircle.color = new Color(255, 255, 255, 145);
            hoverText.text = "";
        }
    }
}
