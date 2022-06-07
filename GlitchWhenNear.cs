using UnityEngine;
using Kino;

public class GlitchWhenNear : MonoBehaviour
{
    public DigitalGlitch digitalGlitch;
    public AnalogGlitch analogGlitch;
    public float intensity;
    public AudioSource staticSound;

    
    private void OnTriggerEnter(Collider collider)
    {
        Vector3 distanceVector = collider.transform.position - transform.position;
        digitalGlitch.intensity = intensity / distanceVector.magnitude;
        analogGlitch.scanLineJitter = intensity / distanceVector.magnitude * 1.3f;
        analogGlitch.colorDrift = intensity / distanceVector.magnitude * 1.3f;
        staticSound.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        digitalGlitch.intensity = 0;
        analogGlitch.scanLineJitter = 0;
        analogGlitch.colorDrift = 0;
        staticSound.Stop();
    }
}
