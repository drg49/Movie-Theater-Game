using UnityEngine;

public class TrigCounterTrap : MonoBehaviour
{
    public GameObject counterTrap;

    private void OnTriggerEnter()
    {
        counterTrap.SetActive(true);
        Destroy(gameObject);
    }
}
