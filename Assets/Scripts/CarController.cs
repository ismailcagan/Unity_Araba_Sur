using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    private float currentSteerAngle;
    private float currentbreakForce;
    private bool isBreaking;
    
    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle;
    
    [SerializeField] private WheelCollider frontLeftWhereCollider;
    [SerializeField] private WheelCollider frontRightWhereCollider;
    [SerializeField] private WheelCollider rearLeftWhereCollider;
    [SerializeField] private WheelCollider rearRightWhereCollider;
    
    [SerializeField] private Transform frontLeftWhereTransform;
    [SerializeField] private Transform frontRightWhereTransform;
    [SerializeField] private Transform rearLeftWhereTransform;
    [SerializeField] private Transform rearRightWhereTransform;
    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }
    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        isBreaking = Input.GetKey(KeyCode.Space);
    }
    private void HandleMotor()
    {
        frontLeftWhereCollider.motorTorque = verticalInput *motorForce;
        frontRightWhereCollider.motorTorque = verticalInput = motorForce;
        currentbreakForce = isBreaking ? breakForce : 0f;

        if (isBreaking)
        {
            ApplyBreaking();
        }
    }
    private void ApplyBreaking()
    {
        frontRightWhereCollider.brakeTorque = currentbreakForce;
        frontLeftWhereCollider.brakeTorque = currentbreakForce;
        rearLeftWhereCollider.brakeTorque = currentbreakForce;
        rearRightWhereCollider.brakeTorque = currentbreakForce;
    }
    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWhereCollider.steerAngle = currentSteerAngle;
        frontRightWhereCollider.steerAngle = currentSteerAngle;
    }
    private void UpdateWheels()
    {
        updateSingleWheel(frontLeftWhereCollider, frontLeftWhereTransform);
        updateSingleWheel(frontRightWhereCollider, frontRightWhereTransform);
        updateSingleWheel(rearRightWhereCollider, rearRightWhereTransform);
        updateSingleWheel(rearLeftWhereCollider, rearLeftWhereTransform);
    }

    private void updateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
}
