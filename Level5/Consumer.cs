using System.Collections.Generic;
using UnityEngine;

public class Consumer : MonoBehaviour
{

    GameObject[] portions;
    int currentIndex;
    float lastChange;
    float interval = 1f;
    public AudioSource chompAudio;
    public List<BoxCollider> collidersToDisable;

    void Start()
    {
        bool skipFirst = transform.childCount > 4;
        portions = new GameObject[skipFirst ? transform.childCount-1 : transform.childCount];
        for (int i = 0; i < portions.Length; i++)
        {
            portions[i] = transform.GetChild(skipFirst ? i + 1 : i).gameObject;
            if (portions[i].activeInHierarchy)
                currentIndex = i;
        }
    }

    void Update()
    {
        if (Time.time - lastChange > interval && currentIndex != portions.Length)
        {
            Consume();
            lastChange = Time.time;
        }
    }

    void Consume()
    {
        chompAudio.Play();
        foreach (BoxCollider collider in collidersToDisable)
        {
            if (collider != null)
            {
                collider.enabled = false;
            }
        }
        if (currentIndex != portions.Length)
            portions[currentIndex].SetActive(false);
        currentIndex++;
        if (currentIndex > portions.Length)
            currentIndex = 0;
        else if (currentIndex == portions.Length)
        {
            FoodRatio.addToRatio = true;
            foreach (BoxCollider collider in collidersToDisable)
            {
                if (collider != null)
                {
                    collider.enabled = true;
                }
            }
            return;
        }
        portions[currentIndex].SetActive(true);
    }

}
