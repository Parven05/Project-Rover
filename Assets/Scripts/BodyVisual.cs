using StarterAssets;
using UnityEngine;

public class BodyVisual : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;

    [SerializeField] private ThirdPersonController thirdPersonController;
    private void Update()
    {
        if(thirdPersonController.IsRoverMoving())
        {
            transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
        }
    }
}
