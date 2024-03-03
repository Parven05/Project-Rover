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


    private bool isMoving = false;
    private bool canMove = true;


    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        HandleHandBrake();
        UpdateWheels();
    }


    private void HandleHandBrake()
    {
        frontRightWheelCollider.brakeTorque = isBreaking ? Mathf.Infinity : 0;
        frontLeftWheelCollider.brakeTorque = isBreaking ? Mathf.Infinity : 0;
        rearLeftWheelCollider.brakeTorque = isBreaking ? Mathf.Infinity : 0;
        rearRightWheelCollider.brakeTorque = isBreaking ? Mathf.Infinity : 0;
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);

        isBreaking = Input.GetKey(KeyCode.Space);

        isMoving = horizontalInput != 0 || verticalInput != 0;
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

    private void ApplyBreaking()
    {
        if (!canMove) // Stop instantly if the truck can't move
        {
            frontRightWheelCollider.brakeTorque = Mathf.Infinity;
            frontLeftWheelCollider.brakeTorque = Mathf.Infinity;
            rearLeftWheelCollider.brakeTorque = Mathf.Infinity;
            rearRightWheelCollider.brakeTorque = Mathf.Infinity;
        }
        else // Apply regular braking force
        {
            frontRightWheelCollider.brakeTorque = currentbreakForce;
            frontLeftWheelCollider.brakeTorque = currentbreakForce;
            rearLeftWheelCollider.brakeTorque = currentbreakForce;
            rearRightWheelCollider.brakeTorque = currentbreakForce;
        }
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

}
