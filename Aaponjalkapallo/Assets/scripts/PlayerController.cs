using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

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
    public Animator animator;
    PhotonView view;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        view = GetComponent<PhotonView>();
    }

    void Update()
    {
        if(view.IsMine)
        {
            CheckIfGrounded();
            Move();
            Jump();
        }
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
        animator.SetFloat("Speed", targetSpeed);
        controller.Move(MoveDir * targetSpeed * Time.deltaTime);
    }

    private void CheckIfGrounded()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        animator.SetBool("Grounded", isGrounded);
        if(isGrounded)
        {
            velocity.y = -2;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    private void Jump()
    {
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}