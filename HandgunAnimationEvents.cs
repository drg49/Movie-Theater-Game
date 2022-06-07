using UnityEngine;

public class HandgunAnimationEvents : MonoBehaviour
{
    public void LogSomething()
    {
        gameObject.GetComponent<Animator>().SetBool("Fire", false);
    }
}
