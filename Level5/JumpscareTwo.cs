using Kino;
using UnityEngine;

public class JumpscareTwo : MonoBehaviour
{
    public GameObject staticAudio;
    public AudioSource glitchAudio;
    public DigitalGlitch digitalGlitch;
    public AnalogGlitch analogGlitch;
    public GameObject magician;
    public AudioSource pianoMusic;
    public GameObject scaryGirlImage;
    public AudioSource screamAudio;
    public GameObject nextEventTrigger;

    private void OnTriggerEnter(Collider other)
    {
        nextEventTrigger.SetActive(true);
        Destroy(staticAudio);
        glitchAudio.Play();
        digitalGlitch.enabled = false;
        analogGlitch.enabled = false;
        Destroy(magician);
        Invoke("JumpScare", 4);
        pianoMusic.Stop();
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    private void JumpScare()
    {
        screamAudio.Play();
        scaryGirlImage.SetActive(true);
        Invoke("HideImage", 1);
    }

    private void HideImage()
    {
        Destroy(scaryGirlImage);
    }
}
