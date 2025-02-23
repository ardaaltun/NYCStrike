using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float xSensitivity = 100f;
    public float ySensitivity = 100f;
    public Vector2 clamp;
    public Transform playerBody; // Assign Character (Parent) in Inspector
    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor to center
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * xSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * ySensitivity * Time.deltaTime;

        // Rotate camera up/down
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, clamp.x, clamp.y);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotate the player left/right
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
