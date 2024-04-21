using UnityEngine;

public class ObjectFollower : MonoBehaviour
{
    [SerializeField] private Transform targetObject;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float objectMoveSpeed = 10f;

    private void LateUpdate()
    {
        if(targetObject)
        transform.position = Vector3.Lerp(transform.position, targetObject.position + offset, Time.deltaTime * objectMoveSpeed);
    }
}
