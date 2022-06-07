using UnityEngine;
using UnityEngine.UI;

public class TrashRatio : MonoBehaviour
{
    public static int trashPickedUp = 0;
    public static bool addToRatio = false;

    private void Start()
    {
        gameObject.GetComponent<Text>().text = $"{trashPickedUp} / 5";
    }

    private void Update()
    {
        if (addToRatio)
        {
            AddToRatio();
            addToRatio = false;
        }
    }

    public void AddToRatio()
    {
        trashPickedUp += 1;
        gameObject.GetComponent<Text>().text = $"{trashPickedUp} / 5";
    }
}
