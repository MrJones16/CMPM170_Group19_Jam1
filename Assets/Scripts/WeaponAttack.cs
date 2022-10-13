using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public int WeaponDamage;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        //Weapon Swing
        if((Input.GetMouseButtonDown(0))){
=======
        if(Input.GetKeyDown(KeyCode.K)){
>>>>>>> fe1bddccb38554e60f6f73276665218b0fd23e91
            animator.SetTrigger("Attack");
        }
    }

}