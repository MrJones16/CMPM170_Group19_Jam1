using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordCollisionHandler : MonoBehaviour
{
    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag == "sword"){
            collider.gameObject.GetComponent<killCount>().onKill();
            Destroy(this.gameObject);
        }
    }
}
