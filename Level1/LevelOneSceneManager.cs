using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelOneSceneManager : MonoBehaviour
{
    /// Objects to DESTROY when Level 5 loads
    public List<GameObject> gameObjectsToDestroyOnLvlFive;

    [Header("STRINGS")]
    public string lvlFivePlayerDialogueOne;
    public string lvlFiveObjOne;

    // Objects to ACTIVATE when Level 5 loads
    [Header("ACTIVATE ON LVL 5")]
    public GameObject fpsPlayer;
    public Transform levelFiveSpawn;
    public GameObject silentAmbience;

    // Objects to alter
    public List<GameObject> tvObjects;

    // UI
    public Text msgOne;
    public Text menuObjOne;

    private void Start()
    {
        if (LevelManager.isLevelFive)
        {
            Debug.Log("Level 5 has started");
            fpsPlayer.SetActive(true);
            fpsPlayer.GetComponent<CharacterController>().enabled = false;
            fpsPlayer.transform.position = levelFiveSpawn.position;
            fpsPlayer.GetComponent<CharacterController>().enabled = true;
            msgOne.text = lvlFivePlayerDialogueOne;
            menuObjOne.text = lvlFiveObjOne;
            menuObjOne.color = new Color(255, 255, 255, 255);
            foreach (GameObject gameObj in gameObjectsToDestroyOnLvlFive)
            {
                Destroy(gameObj);
            }
            silentAmbience.SetActive(true);
            foreach (GameObject gameObj in tvObjects)
            {
                gameObj.SetActive(false);
            }
        }
        else // IF LEVEL 1
        {
            Debug.Log("Level 1 has started");
        }
    }
}
