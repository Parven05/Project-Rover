using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float mouseSensitivityX;
    [SerializeField] private float mouseSensitivityY;
   void Update()
   {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up, mouseX * mouseSensitivityX * Time.deltaTime);
        transform.Rotate(Vector3.right, mouseY * mouseSensitivityY * Time.deltaTime);

   }
}
