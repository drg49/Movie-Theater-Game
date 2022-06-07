using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class FoodRatio : MonoBehaviour
{
    public static int foodEaten = 0;
    public static bool addToRatio = false;
    private bool finishedEating = false;

    public GameObject chompAudio;
    public Animator fridge;
    public AudioSource fridgeClose;
    public GameObject fridgeLight;
    public List<Light> lightsToTurnOff;
    public AudioSource powerOutageSound;
    public GameObject silentAmbience;
    public GameObject pianoHorror;
    public GameObject magician;
    public GameObject jumpscare;
    public FirstPersonController fpController;

    private void Start()
    {
        gameObject.GetComponent<Text>().text = $"{foodEaten} / 7";
    }

    private void Update()
    {
        if (addToRatio)
        {
            AddToRatio();
            addToRatio = false;
        }
        if (foodEaten == 7 && !finishedEating)
        {
            fpController.m_WalkSpeed = 1.2f;
            fpController.m_RunSpeed = 1.2f;
            Invoke("CloseFridge", 2);
            Invoke("ShutOffLights", 3);
            finishedEating = true;
        }
    }

    private void AddToRatio()
    {
        foodEaten += 1;
        gameObject.GetComponent<Text>().text = $"{foodEaten} / 7";
    }

    private void CloseFridge()
    {
        gameObject.GetComponent<Text>().text = "";
        fridgeClose.Play();
        fridge.SetTrigger("CloseFridge");
        Destroy(fridgeLight);
    }

    private void ShutOffLights()
    {
        Destroy(silentAmbience);
        powerOutageSound.Play();
        RenderSettings.fog = true;
        RenderSettings.fogColor = Color.black;
        RenderSettings.fogDensity = 0.3f;
        magician.SetActive(true);
        jumpscare.SetActive(true);
        Destroy(chompAudio);
        foreach(Light light in lightsToTurnOff)
        {
            light.enabled = false;
        }
        pianoHorror.SetActive(true);
    }
}
