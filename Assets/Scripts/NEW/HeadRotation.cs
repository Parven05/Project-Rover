using UnityEngine;

public class HeadRotation : MonoBehaviour
{
    public float horizontalRotationSpeed = 5.0f;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up, mouseX * horizontalRotationSpeed * Time.deltaTime);
    }
}
