using StarterAssets;
using System;
using System.Collections;
using UnityEngine;

public class HeadVisual : MonoBehaviour
{
    [SerializeField] private float leanAngle = 5.0f;
    [SerializeField] private float headLeanForce = 10.0f;
    [SerializeField] private float returDelay = 5.0f;
    [SerializeField] private ThirdPersonController thirdPersonController;

    private Vector3 originalLocalRotation;
    private bool isMovingFirstFrame = true;
    Coroutine coroutine;

    private VisualMode visualMode;
    public enum VisualMode
    {
        Normal,Sway
    }

    private void Start()
    {
        originalLocalRotation = transform.localEulerAngles;
    }

    private void Update()
    {
        HandleSway();

        switch (visualMode)
        {
            case VisualMode.Normal:

                SwayToNormal();

                break;

            case VisualMode.Sway:

                NormalToSway();

                break;
        }
    }

    private void HandleSway()
    {
        if(thirdPersonController.IsRoverMoving() && isMovingFirstFrame)
        {
            visualMode = VisualMode.Sway;
            isMovingFirstFrame = false;
        }
        else
        {
            isMovingFirstFrame = true;
        }
    }

    private void SwayToNormal()
    {
        // Smoothly return the head to its original position
        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(originalLocalRotation), Time.deltaTime * headLeanForce);
    }

    private void NormalToSway()
    {
        // Lean the head when the rover is moving
        float targetLeanAngle = Mathf.Clamp(leanAngle, -45f, 45f); // Clamp the lean angle for safety
        Vector3 targetRotation = new Vector3(targetLeanAngle, originalLocalRotation.y, originalLocalRotation.z);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(targetRotation), Time.deltaTime * headLeanForce);

        if (coroutine == null)
        {
            coroutine = StartCoroutine(MoveBackToOriginal());
        }
    }

    private IEnumerator MoveBackToOriginal()
    {
        yield return new WaitForSeconds(returDelay);
        visualMode = VisualMode.Normal;
        coroutine = null;
    }
}
