using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 2.0f;
    public bool invertY = false;

    private float rotationX = 0.0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        if (invertY)
        {
            mouseY *= -1f;
        }

        transform.Rotate(Vector3.up * mouseX);

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        Camera.main.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
    }
}