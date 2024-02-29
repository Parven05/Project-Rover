using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollower : MonoBehaviour
{
    [SerializeField] private Transform targetObject;
    [SerializeField] private Vector3 offset;

    private void LateUpdate()
    {
        transform.position = targetObject.position + offset;
    }
}
