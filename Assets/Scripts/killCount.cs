using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killCount : MonoBehaviour
{
    public musicControl musicSystem;
    public EnemySpawner enemySpawner;
    public int kills;
    public void onKill(){
        kills += 1;
        if (kills ==20){
            musicSystem.medEnemiesMusic();
            enemySpawner.setIntervals(1f);
        }
        if (kills ==50){
            musicSystem.highEnemiesMusic();
            enemySpawner.movementInterval = .5f;
            enemySpawner.movementSpeed = 1.5f;
        }
    }
}
