using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    private Transform cameraTransform;
    public TextMeshProUGUI debugText;
    public TextMeshProUGUI debugText2;
    Rigidbody rb;
    float grav = Physics.gravity.magnitude;

    private bool willJump;
    
    void Start()
    {
        cameraTransform = Camera.main.transform;
        rb = this.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!willJump && Input.GetKeyDown(KeyCode.Space))
            willJump = true;
    }

    private void FixedUpdate()
    {
        //Jumping
        if (willJump)
        {
            willJump = false;
            rb.angularVelocity = Vector3.zero;
            rb.AddForce(Vector3.up * grav * 0.5f, ForceMode.VelocityChange);
            rb.AddTorque((PlayerRotations.Instance.RoundedRotation * Vector3.right) * (Mathf.PI / 2), ForceMode.VelocityChange);
        }

        //Sliding
        float playerSpeed = 10;
        Vector3 inputVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * playerSpeed;
        inputVector = PlayerRotations.Instance.CameraRotationAlongY * inputVector;
        if (inputVector.magnitude > playerSpeed)
            inputVector = inputVector.normalized * playerSpeed;
        //Scale current player velocity onto inputVector. Is the current speed less than desired by input?
        if (Vector3.Dot(inputVector.normalized, rb.velocity) < inputVector.magnitude)
        {
            Vector3 velocityDisplacement = inputVector - rb.velocity;
            rb.AddForce(velocityDisplacement * 0.25f, ForceMode.VelocityChange);
        }

        //Rotate On Face
        float inputRotateSpeed = Input.GetAxis("Rotate1") * Mathf.PI * 2;
        float appliedRotation = inputRotateSpeed - rb.angularVelocity.y;
        rb.AddTorque(Vector3.up * appliedRotation, ForceMode.Acceleration);
    }
}
