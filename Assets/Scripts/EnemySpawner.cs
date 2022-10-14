using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
   private float savedTime = 0f;
   public GameObject Player;
   public float movementSpeed = 2f;
   public float movementInterval = 2f;
   public List<GameObject> spawnPositions;
   public GameObject enemy;
   public float spawnDelay = 5f;

   public float spawnInterval = 2f;
    // Start is called before the first frame update
    private bool gameStarted = false;

    void Start()
    {
        savedTime = Time.time;
    }

    public void startGame(){
        savedTime = Time.time + spawnDelay;
        gameStarted = true;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameStarted)
        if (Time.time >= savedTime + spawnInterval){
            savedTime = Time.time;
            SpawnEnemy();
        }
    }
    private void SpawnEnemy(){
        int randomNumber = Random.Range(0, 6);
        Instantiate(enemy, spawnPositions[randomNumber].transform.position, transform.rotation);
    }
    public void setIntervals(float speed){
        movementInterval = speed;
        spawnInterval = speed;
    }
}
