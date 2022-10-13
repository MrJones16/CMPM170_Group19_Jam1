using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PC : MonoBehaviour
{
    public float speed;
    public Rigidbody rigidBody;
    public Animator animator;

    void Update()
    {  
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");

        var movement = new Vector3(horizontal, 0, vertical);

        rigidBody.velocity = movement * speed;

        // Added to update the animator.
        animator.SetFloat("HM", horizontal);
        animator.SetFloat("VM", vertical);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }
}