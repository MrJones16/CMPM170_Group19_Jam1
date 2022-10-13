using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordCollisionHandler : MonoBehaviour
{
    void OnTriggerEnter(Collider collider){
        collider.gameObject.GetComponent<killCount>().onKill();
        Destroy(this.gameObject);
    }
}
