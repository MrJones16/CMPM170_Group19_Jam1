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
        if (kills ==45){
            musicSystem.highEnemiesMusic();
            enemySpawner.setIntervals(0.5f);
        }
    }
}
