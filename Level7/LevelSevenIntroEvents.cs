using Kino;
using UnityEngine;
using UnityEngine.UI;

// This scripts hides the cursor and loads the NPC during the intro cutscene.
public class LevelSevenIntroEvents : MonoBehaviour
{
    public GameObject canvas;
    public GameObject scaryGirl;
    public AnalogGlitch bedCamAnalog;
    public DigitalGlitch bedCamDigital;
    public Text msgOne;
    public GameObject creepyMusic;
    public AudioSource screamAudio;
    public GameObject staticAudio;
    private bool stopUpdate = false;
    private bool stopSecondUpdate = false;
    private bool stopThirdUpdate = false;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        canvas.GetComponent<PauseMenu>().enabled = false;
    }

    void Update()
    {
        if (msgOne.color.a >= 0.01f && !stopUpdate)
        {
            float alpha = msgOne.color.a / 200;
            bedCamDigital.intensity -= alpha;
            bedCamAnalog.colorDrift -= alpha;
            bedCamAnalog.horizontalShake -= alpha;
            bedCamAnalog.verticalJump -= alpha;
            bedCamAnalog.scanLineJitter -= alpha;
        }

        if (bedCamAnalog.colorDrift <= 0 && !stopUpdate)
        {
            Destroy(staticAudio);
            Destroy(bedCamDigital);
            Destroy(bedCamAnalog);
            stopUpdate = true;
        }

        if (bedCamAnalog == null && msgOne.color.a == 0 && !stopSecondUpdate)
        {
            Invoke("LoadScaryGirl", 2.7f);
            stopSecondUpdate = true;
        }

        if (scaryGirl.GetComponent<Animator>().GetAnimatorTransitionInfo(0).IsName("LookBehind -> MoveToPlayer") && !stopThirdUpdate)
        {
            Destroy(creepyMusic);
            screamAudio.Play();
            scaryGirl.GetComponent<MoveNpc>().enabled = true;
            stopThirdUpdate = true;
        }
    }

    private void LoadScaryGirl()
    {
        scaryGirl.SetActive(true);
    }
}
