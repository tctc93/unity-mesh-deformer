using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera mainCam;

    public float moveSpeed = 10f;
    public float fastMoveSpeed = 30f;
    public float mouseSensitivity = 3f;

    float rotationX = 0f;
    float rotationY = 0f;

    void Start()
    {
        Vector3 angles = mainCam.transform.eulerAngles;
        rotationX = angles.y;
        rotationY = angles.x;
    }

    void Update()
    {
        // Activate camera look only when RMB is held
        if (Input.GetMouseButton(1))
        {
            Cursor.lockState = CursorLockMode.Locked;

            // Mouse look
            rotationX += Input.GetAxis("Mouse X") * mouseSensitivity * 100f * Time.deltaTime;
            rotationY -= Input.GetAxis("Mouse Y") * mouseSensitivity * 100f * Time.deltaTime;

            rotationY = Mathf.Clamp(rotationY, -90f, 90f);

            mainCam.transform.rotation = Quaternion.Euler(rotationY, rotationX, 0);

            // Movement
            float speed = Input.GetKey(KeyCode.LeftShift) ? fastMoveSpeed : moveSpeed;

            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Vector3 move = transform.forward * v + transform.right * h;

            // Vertical movement
            if (Input.GetKey(KeyCode.E))
                move += Vector3.up;
            if (Input.GetKey(KeyCode.Q))
                move += Vector3.down;

            mainCam.transform.position += move * speed * Time.deltaTime;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
