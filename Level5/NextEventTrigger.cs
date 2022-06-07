using UnityEngine;
using UnityEngine.Video;

public class NextEventTrigger : MonoBehaviour
{
    private bool isReady = false;
    public GameObject scaryGirlFace;
    public GameObject tvVideo;
    public GameObject tvLight;
    public GameObject tvSound;
    public GameObject tvInteract;
    public VideoClip devilVideo;
    public AudioSource creepyMusic;

    private void OnTriggerEnter()
    {
        isReady = true;
    }
    void Update()
    {
        if (isReady && scaryGirlFace == null)
        {
            tvVideo.GetComponent<VideoPlayer>().clip = devilVideo;
            tvVideo.SetActive(true);
            tvLight.SetActive(true);
            tvSound.SetActive(true);
            tvSound.GetComponent<AudioSource>().volume = 0.12f;
            tvInteract.SetActive(true);
            creepyMusic.Play();
            isReady = false;
        }
    }
}
