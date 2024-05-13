using StarterAssets;
using UnityEngine;

public class BodyVisual : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Animator headBounceAnim;
    [SerializeField] private ThirdPersonController thirdPersonController;

    private void Update()
    {
        if(thirdPersonController.IsRoverMoving())
        {
            headBounceAnim.SetBool("isMove", false);
            transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
        }
        else
        {
            headBounceAnim.SetBool("isMove", true);
        }
    }
}
