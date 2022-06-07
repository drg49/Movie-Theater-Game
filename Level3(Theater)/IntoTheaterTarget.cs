using UnityEngine;

public class IntoTheaterTarget : MonoBehaviour
{
    public GameObject customerOnEnter;

    public GameObject customerOne;
    public GameObject customerTwo;
    public GameObject customerThree;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "Cust01")
        {
            Destroy(customerOne);
            customerOnEnter.SetActive(false);
            MoviesInteract.custEvent = false;

            // CustomerTwo will start to do his thing
            customerTwo.GetComponent<CapsuleCollider>().enabled = true;
            customerTwo.GetComponent<Animator>().SetTrigger("StandUp");
        }
        if (collider.name == "Cust02")
        {
            Destroy(customerTwo);
            LevelThreeEventManager.eventTwo = true;
            MoviesInteract.custEvent = false;
        }
        if (collider.name == "Cust03")
        {
            Destroy(customerThree);
        }
    }
}
