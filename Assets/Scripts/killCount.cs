using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killCount : MonoBehaviour
{
    public int kills;
    public void onKill(){
        kills += 1;
    }
}
