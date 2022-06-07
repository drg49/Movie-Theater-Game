using UnityEngine;

public class MovieAudio : MonoBehaviour
{
    public AudioSource movieAudio;
    public bool triggerPlay;

    private void Start()
    {
        movieAudio.enabled = false;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player" && triggerPlay)
        {
            movieAudio.enabled = true;
        }
        else if(collider.tag == "Player" && !triggerPlay)
        {
            movieAudio.enabled = false;
        }
    }
}
