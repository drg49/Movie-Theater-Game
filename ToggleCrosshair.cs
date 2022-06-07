using UnityEngine;

public class ToggleCrosshair : MonoBehaviour
{
    public GameObject handGrab;

    public void SetHandGrab()
    {
        gameObject.SetActive(false);
        handGrab.SetActive(true);
    }

    public void SetDefault()
    {
        handGrab.SetActive(false);
        gameObject.SetActive(true);
    }
}
