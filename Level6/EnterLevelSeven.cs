using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterLevelSeven : MonoBehaviour
{
    public Animator sceneFadeAnim;
    public string LevelSeven;
    private void OnTriggerEnter()
    {
        sceneFadeAnim.SetTrigger("ExitTrigger");
        Invoke("LoadNextLevel", 1.4f);
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(LevelSeven);
    }
}
