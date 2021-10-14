using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;
    
    public float moveSpeed = 8f;
    public float runSpeed = 14f;
    public float jumpHeight =3f;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;

    [SerializeField] private bool isGrounded;

    private Vector3 velocity;

    private Vector3 MoveDir;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        CheckIfGrounded();
        Move();
    }

    private void Move()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        MoveDir = transform.right * xAxis + transform.forward *zAxis;

        float targetSpeed = Input.GetButton("Fire1") ? runSpeed : moveSpeed;

        if(MoveDir == Vector3.zero)
        {
            targetSpeed = 0;
        }
        
        controller.Move(MoveDir * targetSpeed * Time.deltaTime);
    }

    private void CheckIfGrounded()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded)
        {
            velocity.y = -2;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }    
}