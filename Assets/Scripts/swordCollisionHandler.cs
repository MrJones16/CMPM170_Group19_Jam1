using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordCollisionHandler : MonoBehaviour
{
    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.name == "2Hand-Sword"){
            collider.gameObject.GetComponent<killCount>().onKill();
            Destroy(this.gameObject);
        }
    }
}
