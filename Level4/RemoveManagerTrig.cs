using System.Collections.Generic;
using UnityEngine;

public class RemoveManagerTrig : MonoBehaviour
{
    public List<GameObject> managerObjectsToDestroy;

    private void OnTriggerEnter(Collider other)
    {
       foreach(GameObject obj in managerObjectsToDestroy)
        {
            Destroy(obj);
        }
    }
}
