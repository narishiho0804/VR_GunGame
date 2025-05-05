using System.Collections;
using System.Collections.Generic;
using Unity.Android.Types;
using UnityEngine;

public class PC_PlayerMove : MonoBehaviour
{
    private Rigidbody rb;
    private Animator animator;
    private float speed = 15.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))// Wキーを押す。
        {
            animator.SetBool("Walk", true);
            
            rb.AddForce(transform.forward * speed, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("Back", true);
            rb.AddForce(transform.forward * speed * -1, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("WalkRight", true);
            rb.AddForce(transform.right * speed, ForceMode.Acceleration);
            
        }
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("WalkLeft", true);
            rb.AddForce(transform.right * speed * -1, ForceMode.Acceleration);
        }




        if (Input.GetKeyUp(KeyCode.W))// Wキーを押す。
        {
            animator.SetBool("Walk", false);
            
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("Back", false);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("WalkRight", false);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("WalkLeft", false);
        }
    }
}
