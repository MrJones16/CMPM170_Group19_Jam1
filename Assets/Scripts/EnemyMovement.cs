using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject enemySpawnerObject;
    private EnemySpawner enemyspawner;
    private GameObject player;
    private Rigidbody rb;
    float savedTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        enemySpawnerObject = GameObject.Find("EnemySpawner");
        enemyspawner = enemySpawnerObject.GetComponent<EnemySpawner>();
        player = enemyspawner.Player;
        savedTime = Time.time;
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        if (Time.time >= savedTime + enemyspawner.movementInterval){
            savedTime = Time.time;
            Move();
        }
        transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
    }
    private void Move(){
        Vector3 direction = (player.transform.position - this.transform.position);
        direction.Normalize();
        rb.AddForce(direction*enemyspawner.movementSpeed*100);
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player"){
            Debug.Log("Collided w/ player");
            PlayerHealth ph = collider.gameObject.GetComponent<PlayerHealth>();
            ph.PlayerHit(1);
        }
    }
}
