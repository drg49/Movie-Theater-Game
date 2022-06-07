using UnityEngine;

public class OpenNightstand : MonoBehaviour
{
    public Vector3 targetPosition = new Vector3(0, 0, 4f);
    public Vector3 originalPosition;
    public AudioSource openSound;
    public AudioSource closeSound;
    public float speed = 5;
    public bool isOpen = false;
    public GameObject crosshair;
    public bool isObjective;

    private void Start()
    {
        originalPosition = transform.localPosition;
    }

    void Update()
    {
        if (isOpen)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, Time.deltaTime * speed);
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, originalPosition, Time.deltaTime * speed);
        }
    }

    private void OnMouseDown()
    {
        if (KeyOnEnter.isKeyActive)
        {
            if (isOpen)
            {
                closeSound.Play();
                isOpen = false;
            }
            else
            {
                openSound.Play();
                isOpen = true;
                if (isObjective)
                {
                    gameObject.GetComponent<BoxCollider>().enabled = false;
                }
            }
        }
    }

    private void OnMouseOver()
    {
        if (KeyOnEnter.isKeyActive)
        {
            crosshair.GetComponent<ToggleCrosshair>().SetHandGrab();
        }
    }

    private void OnMouseExit()
    {
        if (KeyOnEnter.isKeyActive)
        {
            crosshair.GetComponent<ToggleCrosshair>().SetDefault();
        }
    }
}
