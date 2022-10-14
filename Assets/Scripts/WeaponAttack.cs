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
        //Weapon Swing
        if((Input.GetMouseButtonDown(0))){
            animator.SetTrigger("Attack");
        }
    }

}