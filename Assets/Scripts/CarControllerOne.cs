using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CarControllerOne : MonoBehaviour
{
    [SerializeField] private float speed = 300f;
    [SerializeField] private float rotational_speed = 50f;
    private float horizontal;
    private float vertical;
    public WheelCollider onsol;
    public WheelCollider onsag;
    public WheelCollider arkasol;
    public WheelCollider arkasag;

    private void Update()
    {
        arkasol.motorTorque = speed * Input.GetAxis("Vertical");
        arkasag.motorTorque = speed * Input.GetAxis("Vertical");
        onsol.steerAngle = rotational_speed * Input.GetAxis("Horizontal");
        onsag.steerAngle = rotational_speed * Input.GetAxis("Horizontal");
    }
}
