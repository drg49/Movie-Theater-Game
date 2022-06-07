using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;
    float yRotation = 0f;

    public float xRotationMin = -90f;
    public float xRotationMax = 0f;

    public float yRotationMin = -90f;
    public float yRotationMax = 14f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, xRotationMin, xRotationMax);

        yRotation -= mouseX;
        yRotation = Mathf.Clamp(yRotation, yRotationMin, yRotationMax);

        transform.localRotation = Quaternion.Euler(xRotation, -yRotation, 0f);
    }
}
