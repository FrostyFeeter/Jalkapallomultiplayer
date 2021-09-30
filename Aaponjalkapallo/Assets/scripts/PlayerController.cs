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
    public LayerMask ground;

    [SerializeField] private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
