using UnityEngine;

public class ObjectFollower : MonoBehaviour
{
    [SerializeField] private Transform targetObjectTransform;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float objectMoveSpeed = 10f;
    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, targetObjectTransform.position + offset, Time.deltaTime * objectMoveSpeed);
    }
}
