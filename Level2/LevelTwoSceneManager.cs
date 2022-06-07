using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTwoSceneManager : MonoBehaviour
{
    // Objects to DESTROY when Level 4 loads
    public List<GameObject> gameObjectsToDestroyOnLvlFour;
    public GameObject horrorAmbience; // isolating this one

    [Header("LVL 4 OBJECTIVES")]
    public string lvlFourObjOne;

    // Objects to ACTIVATE when Level 4 loads
    [Header("ACTIVATE ON LVL 4")]
    public GameObject TrashBagHold;
    public GameObject dumpsterOnEnter;
    public GameObject nightAmbience;

    // Objects to ALTER for Level 4
    [Header("ALTER ON LVL 4")]
    public Transform levelFourSpawn;
    public GameObject fpsPlayer;
    public Text objectiveOne;
    public Text menuObjectiveOne;

    void Start()
    {
        if (LevelManager.isLevelFour)
        {
            Debug.Log("Level 4 has started");
            Destroy(horrorAmbience);
            nightAmbience.SetActive(true);
            objectiveOne.text = lvlFourObjOne;
            menuObjectiveOne.text = lvlFourObjOne;
            fpsPlayer.GetComponent<CharacterController>().enabled = false;
            fpsPlayer.transform.position = levelFourSpawn.position;
            fpsPlayer.GetComponent<CharacterController>().enabled = true;
            TrashBagHold.SetActive(true);
            dumpsterOnEnter.SetActive(true);
            foreach (GameObject gameObj in gameObjectsToDestroyOnLvlFour)
            {
                Destroy(gameObj);
            }
        }
        else // IF LEVEL 2
        {
            Debug.Log("Level 2 has started");
        }
    }
}
