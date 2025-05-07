using System.Collections;
using System.Collections.Generic;
using Unity.Android.Types;
using UnityEngine;

public class PC_PlayerMove : MonoBehaviour
{
    public float walkSpeed = 20.0f;
    public float runSpeed = 100.0f;

    private Rigidbody rb;
    private Animator animator;
    private Vector3 moveDirection;

    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        Move();
        Animate();
        
        
    }

    void Move()
    {
        
       
        moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb.AddForce(transform.forward * runSpeed, ForceMode.Acceleration);
            }
            else
            {
                rb.AddForce(transform.forward * walkSpeed, ForceMode.Acceleration);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb.AddForce(transform.right * runSpeed, ForceMode.Acceleration);
            }
            else
            {
                rb.AddForce(transform.right * walkSpeed, ForceMode.Acceleration);
            }

        }
        if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb.AddForce(transform.right * runSpeed * -1, ForceMode.Acceleration);
            }
            else
            {
                rb.AddForce(transform.right * walkSpeed* -1, ForceMode.Acceleration);
            }

        }



        if (Input.GetKey(KeyCode.W) && (Input.GetKey(KeyCode.D)))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                //rb.AddForce(transform.right * runSpeed * -1, ForceMode.Acceleration);
            }
            else
            {
                //rb.AddForce(transform.right * walkSpeed * -1, ForceMode.Acceleration);
            }
        }

        if (Input.GetKey(KeyCode.W) && (Input.GetKey(KeyCode.D)))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb.AddForce(transform.forward + transform.right * runSpeed, ForceMode.Acceleration);
            }
            else
            {
                rb.AddForce(transform.forward + transform.right * walkSpeed, ForceMode.Acceleration);
            }
        }
    }

    void Animate()
    {
        // 状態リセット
        animator.SetBool("Walk", false);
        animator.SetBool("WalkRight", false);
        animator.SetBool("WalkLeft", false);
        animator.SetBool("Run", false);
        animator.SetBool("RunRight", false);
        animator.SetBool("RunLeft", false);


        // 入力に応じてアニメを切り替える
        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetBool("Run", true);
            }
            else
            {
                animator.SetBool("Walk", true);
            }
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetBool("RunRight", true);
            }
            else
            {
                animator.SetBool("WalkRight", true);
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetBool("RunLeft", true);
            }
            else
            {
                animator.SetBool("WalkLeft", true);
            }
        }

        if (Input.GetKey(KeyCode.W) && (Input.GetKey(KeyCode.D)))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetBool("WalkDiagonallyRight", true);
            }
            else
            {
                animator.SetBool("RunDiagonallyRight", true);
            }
        }

    }
}
