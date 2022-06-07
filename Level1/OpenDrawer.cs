using UnityEngine;

public class OpenDrawer : MonoBehaviour
{
    public Vector3 targetPosition = new Vector3(0, 0, 4f);
    public Vector3 originalPosition;
    public AudioSource openSound;
    public AudioSource closeSound;
    public float speed = 5;
    public bool isOpen = false;
    public GameObject crosshair;

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
        if (DresserOnEnter.isDresserActive)
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
            }
        }
    }

    private void OnMouseOver()
    {
        if(DresserOnEnter.isDresserActive)
        {
            crosshair.GetComponent<ToggleCrosshair>().SetHandGrab();
        }
    }

    private void OnMouseExit()
    {
        if (DresserOnEnter.isDresserActive)
        {
            crosshair.GetComponent<ToggleCrosshair>().SetDefault();
        }
    }
}

