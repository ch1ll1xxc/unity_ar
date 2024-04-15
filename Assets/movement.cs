using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float gravity = -9.81f;
    public CharacterController characterController;
    
    private Vector3 velocity;

    void Start() {
        characterController = GetComponent<CharacterController>();    
    }

    void Update() {
        Move();
        ApplyGravity();

        if (Input.GetButton("Jump") && characterController.isGrounded)
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift)){
            moveSpeed *= 2f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift)){
            moveSpeed /= 2f;
        }
    }

    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput);
        moveDirection = transform.TransformDirection(moveDirection);
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
        
    }

    void ApplyGravity()
    {
        if (!characterController.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
            characterController.Move(velocity * Time.deltaTime);
        }
        else
        {
            velocity.y = 0f;
        }
    }

    void Jump()
    {
        velocity.y = jumpForce;
    }
}
