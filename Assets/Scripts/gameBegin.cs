using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameBegin : MonoBehaviour
{
    public musicControl musicSystem;
    public int gameStarted = 0;
    public Button startButton;
    public Canvas theCanvas;
    // Start is called before the first frame update
    private EnemySpawner enemySpawner;
    void Start()
    {
        Button btn = startButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {
        gameStarted = 1;
        Canvas cvs = theCanvas.GetComponent<Canvas>();
        cvs.gameObject.SetActive(false);
        musicSystem.lowEnemiesMusic();
        enemySpawner.startGame();
        //musicSystem.gameStartedMusic();
    }
}
