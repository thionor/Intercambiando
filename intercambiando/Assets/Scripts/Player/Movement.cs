using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;

    private Vector3 moveDirection;
    private Vector3 velocity;

    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;

    [SerializeField] private float jumpHeight;

    private CharacterController controller;

    public Transform model;


    private void Start() {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
        HandleRotation();
    }

    private void Move() {

        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        if(isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        moveDirection = new Vector3(moveX, 0, moveZ);

        if(isGrounded) {
            if(moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift)) {
                Walk();
                
            } else if(moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift)) {
                Run();

            } else if(moveDirection  == Vector3.zero) {
                Idle();
            }

            moveDirection *= moveSpeed;
        }

        controller.Move(moveDirection * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Idle() {

    }

    private void Walk() {
        moveSpeed = walkSpeed;
    }

    private void Run() {
        moveSpeed = runSpeed;
    }

    private void HandleRotation() {

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 currentPosition = transform.position;
        Vector3 newPosition = new Vector3(moveX, 0, moveZ);
        Vector3 positionToLookAt = currentPosition + newPosition;
        transform.LookAt(positionToLookAt);
    }

}
