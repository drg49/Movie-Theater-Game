using UnityEngine;

public class MoveObjectTowards : MonoBehaviour
{
    public Transform target;
    public float speed = 1.0f;
    public static bool startMovement = false;

    void Update()
    {
        if (startMovement)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }
}
