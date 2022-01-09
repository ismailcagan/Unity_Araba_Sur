using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CarControllerTwo : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private bool isFren;
    private float currentFrendForce;
    private float curentDonusAcisi;
    
    [SerializeField] private float maxDonusAcisi;
    [SerializeField] private float motorTorgutForce;
    [SerializeField] private float breakForce;

    [SerializeField] private WheelCollider onSolTekerleriCollider;
    [SerializeField] private WheelCollider onSagTekerleriCollider;
    [SerializeField] private WheelCollider arkaSolTekerleriCollider;
    [SerializeField] private WheelCollider arkaSagTekerleriCollider;

    [SerializeField] private Transform onSolTekerlekTransform;
    [SerializeField] private Transform onSagTekerlekTransform;
    [SerializeField] private Transform arkaSolTekerlekTransform;
    [SerializeField] private Transform arkaSagTekerlekTransform;
    private void FixedUpdate()
    {
        getUserInput(); // araba hareketi için yön tuşları ve fren belirleme
        moveTheCar(); // arabanın hareketi için kuvvet uygulama ve fren
        rotateTheCar(); // arabanın sağ ve sola dönmesi için rotation ayarlama
        rotateTheWheels(); // ön tekerlekleri döndermek için
    }

    private void rotateTheWheels()
    {
        rotateTheWheel(onSolTekerleriCollider,onSolTekerlekTransform);
        rotateTheWheel(onSagTekerleriCollider,onSagTekerlekTransform);
        rotateTheWheel(arkaSolTekerleriCollider,arkaSolTekerlekTransform);
        rotateTheWheel(arkaSagTekerleriCollider,arkaSagTekerlekTransform);
        
    }
    private void rotateTheWheel(WheelCollider tekerlerkCollider,Transform tekerlekTransform)
    {
        Vector3 position;
        Quaternion rotation;
        onSolTekerleriCollider.GetWorldPose(out position, out rotation);
        onSolTekerlekTransform.position = position;
        onSolTekerlekTransform.rotation = rotation;
    }
    private void rotateTheCar()
    {
        // Dönüşler sağlamak için oluşturuldu
        curentDonusAcisi = maxDonusAcisi * horizontalInput;
        onSolTekerleriCollider.steerAngle = curentDonusAcisi;
        onSagTekerleriCollider.steerAngle = curentDonusAcisi;
    }
    private void moveTheCar()
    {
        // on tekerleklere ileri gitmesi için kuvvet uygulandı
        onSolTekerleriCollider.motorTorque = verticalInput * motorTorgutForce;
        onSagTekerleriCollider.motorTorque = verticalInput * motorTorgutForce;
        // fren yapması
        currentFrendForce = isFren ? breakForce : 0f;
        if (isFren)
        {
            onSolTekerleriCollider.brakeTorque = currentFrendForce * 100;
            onSagTekerleriCollider.brakeTorque = currentFrendForce;
            arkaSolTekerleriCollider.brakeTorque = currentFrendForce;
            arkaSagTekerleriCollider.brakeTorque = currentFrendForce;
        }
    }
    private void getUserInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        isFren = Input.GetKey(KeyCode.Space);
    }
}
