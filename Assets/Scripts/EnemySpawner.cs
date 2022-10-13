using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
   private float savedTime = 0f;
   public GameObject Player;
   public float movementSpeed = 10f;
   public float movementInterval = 1f;
   public List<GameObject> spawnPositions;
   public GameObject enemy;

   public float spawnInterval = 2f;
    // Start is called before the first frame update

    void Start()
    {
        savedTime = Time.time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time >= savedTime + spawnInterval){
            savedTime = Time.time;
            SpawnEnemy();
        }
    }
    private void SpawnEnemy(){
        int randomNumber = Random.Range(0, 6);
        Instantiate(enemy, spawnPositions[randomNumber].transform.position, transform.rotation);
    }
}
