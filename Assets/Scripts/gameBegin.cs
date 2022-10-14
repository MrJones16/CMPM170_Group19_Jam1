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
    public Canvas secondCanvas;

    void Start()
    {
        Button btn = startButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
    }
    
    void TaskOnClick()
    {
        gameStarted = 1;
        Canvas cvs = theCanvas.GetComponent<Canvas>();
        musicSystem.lowEnemiesMusic();
        enemySpawner.startGame();
        secondCanvas.gameObject.SetActive(true);

        cvs.gameObject.SetActive(false);
        //musicSystem.gameStartedMusic();
    }
}
