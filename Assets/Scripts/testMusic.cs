using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMusic : MonoBehaviour
{
    public musicControl musicSystem;
    
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            musicSystem.gameStartedMusic();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)){
            musicSystem.lowEnemiesMusic();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)){
            musicSystem.medEnemiesMusic();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4)){
            musicSystem.highEnemiesMusic();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5)){
            musicSystem.endMusic();
        }
    }
}
