using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float rotationSpeed;
    public float distance;
    public float height;
    public float currentRotation;

    void Update()
    {
        float rotationInput = Input.GetAxis("CameraHorizontal");

        currentRotation += rotationInput * rotationSpeed * Time.deltaTime;

        Vector3 offset = Quaternion.Euler(0, currentRotation, 0) * new Vector3(0, height, -distance);
        Vector3 playerPosition = player.position + offset;

        transform.position = playerPosition;
        transform.LookAt(player);
    }
}




