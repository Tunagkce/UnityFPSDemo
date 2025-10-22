using System;
using UnityEngine;


public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;
    public float currentSpeed;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;
    public float walkSpeed = 5f;
    public float sprintSpeed = 9f;
    public float interpolationFromWalkToSpeed = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        currentSpeed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
    }

    // Applying input actions to our characters.
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * currentSpeed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;
        controller.Move(velocity * Time.deltaTime);
        Debug.Log(velocity.y);
    }
    public void Jump()
    {
        if (isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }
    public void StartSprinting()
    {
        sprintSpeed = Mathf.Lerp(walkSpeed, sprintSpeed, interpolationFromWalkToSpeed);
        if(isGrounded)
        currentSpeed = sprintSpeed;
    }
    public void StopSprinting()
    {
        currentSpeed = walkSpeed;
    }

    
}
