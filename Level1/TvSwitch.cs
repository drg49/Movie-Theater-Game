using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class TvSwitch : MonoBehaviour
{
    public GameObject TvEnter;
    public ToggleCrosshair crosshair;
    public Text hoverText;
    public GameObject TvVideo;
    public GameObject TvSound;
    public GameObject TvLight;
    public AudioSource TvOffSound;
    public GameObject msgFour;
    public List<Light> lightsToTurnOn;
    public FirstPersonController fpController;
    public GameObject bedOnEnter;
    public GameObject bedInteract;

    private int timesTried = 0;
    private bool hasUpdateCalled = false;

    private void OnMouseDown()
    {
        if (TvOnEnter.IsTvActive && !IntroPauseGame.GameIsPaused)
        {
            if (LevelManager.isLevelFive)
            {
                Invoke("TurnPowerBackOn", 15);
                TvOffSound.Play();
                timesTried += 1;
                return;
            }
            TurnOffTv();
        }
    }

    private void TurnOffTv()
    {
        TvOffSound.Play();
        Destroy(TvVideo);
        Destroy(TvSound);
        Destroy(TvLight);
        TvOnEnter.IsTvActive = false;
        Destroy(TvEnter);
        crosshair.SetDefault();
        hoverText.text = "";
        Destroy(gameObject);
    }

    void OnMouseOver()
    {
        if (TvOnEnter.IsTvActive)
        {
            crosshair.SetHandGrab();
            hoverText.text = "Turn Off";
        }
    }

    private void OnMouseExit()
    {
        if (TvOnEnter.IsTvActive)
        {
            crosshair.SetDefault();
            hoverText.text = "";
        }
    }

    private void Update()
    {
        if(timesTried == 2 && !hasUpdateCalled)
        {
            msgFour.SetActive(true);
            msgFour.GetComponent<Animator>().SetBool("TriggerFadeIn", true);
            hasUpdateCalled = true;
        }
    }

    private void TurnPowerBackOn()
    {
        bedOnEnter.SetActive(true);
        bedInteract.SetActive(true);
        fpController.m_WalkSpeed = 3.4f;
        fpController.m_RunSpeed = 3.4f;
        Destroy(msgFour);
        RenderSettings.fog = false;
        foreach(Light light in lightsToTurnOn)
        {
            light.enabled = true;
        }
        TurnOffTv();
    }
}
