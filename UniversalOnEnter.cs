using UnityEngine;
using UnityEngine.UI;

public class UniversalOnEnter : MonoBehaviour
{
    // A single script for OnEnter events, instead of making a script for each gameobject
    public bool isActive = false;
    public GameObject defaultCircle;
    public Text hoverText;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            isActive = true;
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            isActive = false;
            hoverText.text = "";
            defaultCircle.GetComponent<ToggleCrosshair>().SetDefault();
            defaultCircle.GetComponent<Image>().color = new Color(255, 255, 255, 145);
        }
    }
}
