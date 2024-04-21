using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float mouseSensitivityX;
    [SerializeField] private float mouseSensitivityY;

    private float rotationX = 0f;
    private float rotationY = 0f;
    void Update()
   {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        //transform.Rotate(Vector3.up, mouseX * mouseSensitivityX * Time.deltaTime);
        //transform.Rotate(Vector3.left, mouseY * mouseSensitivityY * Time.deltaTime);

        rotationX -= mouseY * mouseSensitivityY;
        rotationY -= mouseX * mouseSensitivityX;

        transform.localEulerAngles = new Vector3(Mathf.Clamp(-rotationX,-90,90) , Mathf.Clamp(rotationY, -90, 90), 0f);
   }
}
//using UnityEngine;

//public class CameraMovement : MonoBehaviour
//{
//    [SerializeField] private float mouseSensitivityX = 2f;
//    [SerializeField] private float mouseSensitivityY = 2f;
//    private float rotationX = 0f;

//    void Update()
//    {
//        float mouseX = Input.GetAxis("Mouse X");
//        float mouseY = Input.GetAxis("Mouse Y");

//        // Rotate around the y-axis (left and right)
//        transform.Rotate(Vector3.up, mouseX * mouseSensitivityX * Time.deltaTime);

//        // Calculate rotation around the x-axis (up and down)
//        rotationX -= mouseY * mouseSensitivityY;
//        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

//        // Apply rotation around the x-axis
//        transform.localRotation = Quaternion.Euler(rotationX, transform.localRotation.eulerAngles.y, 0f);
//    }
//}
