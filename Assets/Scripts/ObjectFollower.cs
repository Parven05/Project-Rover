using UnityEngine;

public class ObjectFollower : MonoBehaviour
{
    [SerializeField] private Transform targetObject;
    [SerializeField] private Transform targetObjectRotation;
    [SerializeField] private Vector3 offset;

    private void LateUpdate()
    {
        if(targetObject)
        transform.position = targetObject.position + offset;

        if(targetObjectRotation) 
        transform.rotation = targetObjectRotation.rotation;
    }
}
