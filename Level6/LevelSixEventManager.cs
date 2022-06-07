using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityStandardAssets.Characters.FirstPerson;

public class LevelSixEventManager : MonoBehaviour
{
    public List<GameObject> objectsToDestroyOnLvlSix;
    public List<GameObject> objectsToActivateOnLvlSix;
    public List<GameObject> handObjectsToDeactivate;
    public List<GameObject> objectsToDestroyAfterMagician;
    public GameObject fpsPlayer;
    public GameObject npcNine;
    public GameObject magician;
    public GameObject magicSmoke;
    public GameObject movieSmoke;
    public GameObject orderListUI;
    public GameObject objectiveTwo;
    public GameObject enterLevelSeven;
    public Text menuObjTwo;
    public AudioSource westernHorrorTheme;
    public AudioSource explosionSound;
    public Animator doorAnim;
    public VideoClip astronomersDream;
    public VideoPlayer movieScreen;
    public Image defaultCircle;
    public Text dialogueText;
    public Text hoverText;
    public Transform magicTargetThree;
    private bool lvlSixCustEvent = false;
    private bool activateSecondEvent = false;
    private bool stopUpdate = false;
    private bool eventOne = false;
    private bool eventTwo = false;
    public static bool goGetManager = false;
    public static bool boolTrig = false;
    public string objectiveTwoString;

    void Start()
    {
        if (LevelManager.isLevelSix)
        {
            foreach (GameObject obj in objectsToDestroyOnLvlSix)
            {
                Destroy(obj);
            }
            movieScreen.clip = astronomersDream;
            foreach (GameObject obj in objectsToActivateOnLvlSix)
            {
                obj.SetActive(true);
            }
        }
    }

    private void Update()
    {
        if (magician.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Pointing") && !eventTwo)
        {
            Debug.Log("Do something");
            objectiveTwo.GetComponent<Text>().text = objectiveTwoString;
            objectiveTwo.GetComponent<Animator>().SetBool("TriggerFadeIn", true);
            menuObjTwo.text = objectiveTwoString;
            menuObjTwo.color = new Color(255, 255, 255, 255);
            eventTwo = true;
        }
        if (MagicianInteract.hasTalkedToMagician && fpsPlayer.activeSelf)
        {
            // Magician walks into the theater
            magician.GetComponent<NpcNavMesh>().movePositionTransform = magicTargetThree;
            magician.GetComponent<RotateToTarget>().enabled = false;
            magician.GetComponent<NpcNavMesh>().enabled = true;
            magician.GetComponent<NavMeshAgent>().enabled = true;
            magician.GetComponent<NavMeshAgent>().speed = 2.4f;
            magician.GetComponent<Animator>().SetTrigger("WalkAgain");
            magician.GetComponent<CapsuleCollider>().isTrigger = true;
            fpsPlayer.GetComponent<FirstPersonController>().m_RunSpeed = 2.35f;
            fpsPlayer.GetComponent<FirstPersonController>().m_WalkSpeed = 2.35f;
            foreach (GameObject obj in objectsToDestroyAfterMagician)
            {
                Destroy(obj);
            }
            movieSmoke.SetActive(true);
            enterLevelSeven.SetActive(true);
            MagicianInteract.hasTalkedToMagician = false;
        }
        if (dialogueText.text == "That is no way to answer customers, where is your manager?" && !stopUpdate)
        {
            activateSecondEvent = true;
            stopUpdate = true;
        }
        if (CustomerInteract.custDrinkFulfilled && CustomerInteract.custPopcornFulfilled && !lvlSixCustEvent)
        {
            ResetValues();
            westernHorrorTheme.Play();
            Invoke("StartEarthquake", 3);
            lvlSixCustEvent = true;
        }
        if (LevelManager.isLevelSix && activateSecondEvent && !eventOne)
        {
            Destroy(orderListUI);
            boolTrig = true;
            goGetManager = true;
            eventOne = true;
        }
        else if (goGetManager && fpsPlayer.activeSelf)
        {
            ResetValues();
            foreach(GameObject obj in handObjectsToDeactivate)
            {
                if (obj.activeSelf)
                {
                    obj.SetActive(false);
                }
            }
            westernHorrorTheme.Play();
            Invoke("StartEarthquake", 3);
            goGetManager = false;
        }
    }

    private void StartEarthquake()
    {
        // Earthquake shakes theater
        explosionSound.Play();
        npcNine.GetComponent<TraumaInducer>().enabled = true;
        Invoke("MagicianEntersTheater", 3.5f);
    }

    private void MagicianEntersTheater()
    {
        doorAnim.SetTrigger("OpenDoor");
        Invoke("ActivateSmoke", 1);
        Invoke("ActivateMagician", 1.5f);
        Invoke("CloseDoor", 2.85f);
    }

    private void ActivateSmoke()
    {
        magicSmoke.SetActive(true);
    }

    private void ActivateMagician()
    {
        npcNine.GetComponent<RotateToTarget>().target = magician.transform;
        magician.SetActive(true);
    }

    private void ResetValues()
    {
        Destroy(orderListUI);
        CustomerInteract.customerOrderStarted = false;
        CustomerInteract.custDrinkFulfilled = false;
        CustomerInteract.custPopcornFulfilled = false;
        CustomerInteract.custTicketFulfilled = false;

        RegisterTarget.hasEnteredCollider = false;
        CustomerOnEnter.isCustomerActive = false;

        defaultCircle.color = new Color(255, 255, 255, 145);
        hoverText.text = "";
    }

    private void CloseDoor()
    {
        doorAnim.SetTrigger("CloseDoor");
    }
}
