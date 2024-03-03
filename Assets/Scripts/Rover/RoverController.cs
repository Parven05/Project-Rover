using System;
using UnityEngine;

public class RoverController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    private float currentbreakForce;
    private bool isBreaking;

    private float currentSteerAngle;
    [SerializeField] private float maxSteerAngle;

    [SerializeField] private float motorForce = 1000;
    [SerializeField] private float breakForce = 3000;

    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;

    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheeTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();

        if (isBreaking || HasNoInput())
        {
            ApplyBrake();
        }
        else
        {
            ReleaseBreak();
        }
    }

    private void ReleaseBreak()
    {
        frontRightWheelCollider.brakeTorque = 0;
        frontLeftWheelCollider.brakeTorque = 0;
        rearLeftWheelCollider.brakeTorque = 0;
        rearRightWheelCollider.brakeTorque = 0;
    }

    private bool HasNoInput()
    {
        return verticalInput == 0 && horizontalInput == 0;
    }

    private void ApplyBrake()
    {
        frontRightWheelCollider.brakeTorque = Mathf.Infinity;
        frontLeftWheelCollider.brakeTorque = Mathf.Infinity;
        rearLeftWheelCollider.brakeTorque = Mathf.Infinity;
        rearRightWheelCollider.brakeTorque = Mathf.Infinity;
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);

        isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;
    }


    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheeTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }

    public bool IsRoverMoving()
    {
        return IsWheelMoving(frontLeftWheelCollider) ||
               IsWheelMoving(frontRightWheelCollider) ||
               IsWheelMoving(rearLeftWheelCollider) ||
               IsWheelMoving(rearRightWheelCollider);
    }

    private bool IsWheelMoving(WheelCollider wheelCollider)
    {
        return Mathf.Abs(wheelCollider.rpm) > 0.1f;
    }


}
