using UnityEngine;

public class CameraController : MonoBehaviour
{
    private RotateCamera rotateCamera;

    public float RotationSpeed
    {
        get { return rotateCamera.RotationSpeed; }
        set { rotateCamera.RotationSpeed = value; }
    }

    void Start()
    {
        rotateCamera = GetComponent<RotateCamera>();
    }

    void Update()
    {
        // Example usage: Adjust rotation speed based on some condition
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            RotationSpeed += 30.0f;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            RotationSpeed -= 30.0f;
        }
    }
}
