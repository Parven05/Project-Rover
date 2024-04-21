using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public enum LookMode { LookAt,LookAtInverted,CameraForward,CameraForwardInverted }

    [SerializeField] private LookMode lookMode;
    [SerializeField] private Transform targetToLookTransform;

    private Canvas canvas;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        canvas.worldCamera = Camera.main;
    }
    void LateUpdate()
    {
        switch(lookMode)
        {
            case LookMode.LookAt:
                transform.LookAt(targetToLookTransform);
                break;
            case LookMode.LookAtInverted:
                Vector3 dir = transform.position - targetToLookTransform.position;
                transform.LookAt(transform.position + dir);
                break;
            case LookMode.CameraForward:
                transform.forward = targetToLookTransform.forward;
                break;
            case LookMode.CameraForwardInverted:
                transform.forward = -targetToLookTransform.forward;
                break;
        }
    }
}
