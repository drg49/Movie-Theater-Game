using UnityEngine;

public class SceneFadeEvents : MonoBehaviour
{
    public CharacterController fpsPlayer;
    public GameObject sceneFadeText;

    // All of the methods below get called as events on the SceneFade Animator controller

    public void EnableFpsPlayer()
    {
        fpsPlayer.enabled = true;
    }

    public void DisableFpsPlayer()
    {
        fpsPlayer.enabled = false;
    }

    public void DelayBlackScreen()
    {
        sceneFadeText.SetActive(true);
        if (LevelManager.isLevelFive) return;
        Invoke("FadeBackIn", 4);
    }

    private void FadeBackIn()
    {
        gameObject.GetComponent<Animator>().SetTrigger("ExitTrigger");
        sceneFadeText.SetActive(false);
        LevelThreeEventManager.eventThree = true;
    }
}
