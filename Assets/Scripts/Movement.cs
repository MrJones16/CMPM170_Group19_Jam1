using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    PlayerInput playerinput;
    CharacterController characterC;
    // Start is called before the first frame update
    Animator animator;
    Vector2 InputAxis;
    Vector3 Direction;
    bool isMoving;

    void Awake(){
        playerinput = new PlayerInput();
        characterC = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        playerinput.CharacterControl.Move.started += onInput;
        playerinput.CharacterControl.Move.canceled += onInput;
        playerinput.CharacterControl.Move.performed += onInput;
       
        
    }

    void onInput(InputAction.CallbackContext context){
        InputAxis = context.ReadValue<Vector2>();
        Direction.x =  InputAxis.x;
        Direction.z =  InputAxis.y;
        isMoving =  InputAxis.x!= 0 ||  InputAxis.y != 0;
           
    }

    // Update is called once per frame

    void AnimationHandling(){
        bool isRunning = animator.GetBool("isRunning");
        
        if(isMoving && !isRunning){
            animator.SetBool("isRunning",true);
            Debug.Log(Direction);
        }

        else if(!isMoving && isRunning){
            animator.SetBool("isRunning",false);
        }
    }
    void Update()
    {
        AnimationHandling();
        characterC.Move(Direction * Time.deltaTime * moveSpeed);
        
    }

    void OnEnable(){
        playerinput.CharacterControl.Enable();
        
    }
     void OnDisable(){
        playerinput.CharacterControl.Disable();
    }
}

