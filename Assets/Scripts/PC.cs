using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PC : MonoBehaviour
{
    public float speed;
    public Rigidbody rigidBody;
    public Animator animator;
    public Collider sword;
    public GameObject worldreference;
    public Vector3 worldPosition;
    Plane plane = new Plane(Vector3.up, 0);

    void Start(){
        Physics.IgnoreCollision(sword.GetComponent<Collider>(), GetComponent<Collider>());
    }
    void Update()
    {
        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance))
        {
            worldPosition = ray.GetPoint(distance);
        }
        rigidBody = gameObject.GetComponent<Rigidbody>();
        worldPosition += new Vector3(0,gameObject.transform.position.y,0);
        gameObject.transform.LookAt(worldPosition);
    }

    void FixedUpdate()
    {  
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        Vector3 forward = worldreference.transform.forward * vertical;
        Vector3 right = worldreference.transform.right * horizontal;
        Vector3 movement = forward + right;
        Vector3 direction = transform.forward - movement;
        movement.Normalize();
        transform.position += movement *speed * Time.deltaTime;
        
        
        // Added to update the animator.
        animator.SetFloat("HM", direction.x);
        animator.SetFloat("VM", direction.z);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }
}