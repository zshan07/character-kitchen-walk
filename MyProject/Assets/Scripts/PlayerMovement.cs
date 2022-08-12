using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private Vector3 moveDirection;
    public CharacterController controller;
    private Vector3 velocity;

    [SerializeField] bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundmask;
    [SerializeField] private float gravity;

    private Animator anim;
    void Start()
    {
        controller=GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        Move();
    }
    void Move()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundmask);

        if (isGrounded && velocity.y<0)
        {
            velocity.y = -2f;
        }

        float moveZ = Input.GetAxis("Vertical");

        moveDirection = new Vector3(0, 0, moveZ);
        moveDirection = transform.TransformDirection(moveDirection);
       
        
        if (isGrounded)
        {
            if (moveDirection != Vector3.zero)
            {
                //walking
                Walk();
            }
            else if (moveDirection == Vector3.zero)
            {
                //idle
                Idle();
            }
            moveDirection *= moveSpeed;  
        }


        controller.Move(moveDirection * Time.deltaTime);

        //adding gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void Idle()
    {
        //anim.SetFloat("Speed", 0);
        anim.SetBool("walk", false);
    }
    void Walk()
    {
        //anim.SetFloat("Speed", 0.5f);
        anim.SetBool("walk", true);
    }
}
