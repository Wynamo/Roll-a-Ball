using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // Reference to the object you want to follow and rotate around
    public float rotationSpeed;
    public float distance = 5.0f; // Distance from the object
    public float height = 2.0f; // Height above the object
    private float currentRotation;

    void Update()
    {
        float rotationInput = Input.GetAxis("CameraHorizontal"); // Assumes "n" and "m" keys correspond to horizontal input

        // Update the camera rotation based on input
        currentRotation += rotationInput * rotationSpeed * Time.deltaTime;

        // Calculate the position offset
        Vector3 offset = Quaternion.Euler(0, currentRotation, 0) * new Vector3(0, height, -distance);
        Vector3 targetPosition = target.position + offset;

        // Update the camera position to follow the object
        transform.position = targetPosition;
        transform.LookAt(target); // Make the camera look at the object
    }
}




