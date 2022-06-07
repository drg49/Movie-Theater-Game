using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public GameObject bedPlayer;
    public GameObject firstPerson;
    public GameObject msgOne;
    public GameObject msgTwo;
    public GameObject crosshair;
    public GameObject msgThree;
    public bool isEnabled = false;
    public static bool enablePauseMenu = false;

    void Start()
    {
        if (!LevelManager.isLevelFive)
        {
            firstPerson.SetActive(false);
            bedPlayer.SetActive(true);
            crosshair.SetActive(false);
            Invoke("EnableScript", 34);
        }
    }

    private void EnableScript()
    {
        isEnabled = true;
        msgThree.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isEnabled && !LevelManager.isLevelFive)
        {
            firstPerson.SetActive(true);
            Destroy(bedPlayer);
            crosshair.SetActive(true);
            enablePauseMenu = true;
            Destroy(msgOne);
            Destroy(msgTwo);
            Destroy(msgThree);
            Destroy(gameObject);
        }
    }
}
