using UnityEngine;

public class DestroyScaryGirl : MonoBehaviour
{
    public GameObject scaryGirl;
    public GameObject pressSpace;
    public GameObject fpsController;
    public GameObject canvas;
    public GameObject defaultCircle;
    public GameObject fireplaceAudio;
    private bool readyToGetUp = false;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "ScaryGirl")
        {
            fireplaceAudio.SetActive(true);
            Destroy(GetComponent("LevelSevenIntroEvents"));
            Invoke("ShowInstructionalText", 2.5f);
            Destroy(scaryGirl);
        }
    }

    private void ShowInstructionalText()
    {
        pressSpace.SetActive(true);
        readyToGetUp = true;
    }

    private void Update()
    {
        if (readyToGetUp && Input.GetKeyDown(KeyCode.Space))
        {
            canvas.GetComponent<PauseMenu>().enabled = true;
            fpsController.SetActive(true);
            defaultCircle.SetActive(true);
            Destroy(pressSpace);
            Destroy(gameObject);
        }
    }
}
