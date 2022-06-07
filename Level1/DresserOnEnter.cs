using UnityEngine;

public class DresserOnEnter : MonoBehaviour
{
    public static bool isDresserActive = false;
    public GameObject crosshair;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            isDresserActive = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            isDresserActive = false;
            crosshair.GetComponent<ToggleCrosshair>().SetDefault();
        }
    }
}
