using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float invincibilityDurationSeconds = 3;
    [SerializeField] private float invincibilityDeltaTime;
    [SerializeField] private GameObject model;
    public int MaxHealth = 3;
    public int CurrentHealth;
    private bool isInvulnarable;
    // Start is called before the first frame update
    public musicControl musicSystem;
    public Text killCounter;
    public killCount killCount;
    public Text healthCounter;
    public Text gameOverText;

    private PC ph;

    void Start()
    {
        CurrentHealth = MaxHealth;
        isInvulnarable = false;
        ph = gameObject.GetComponent<PC>();
    }
    private void Update() {
        killCounter.text = "Kills: " + killCount.kills;
        healthCounter.text = "Health: " + CurrentHealth;
    }

    public void PlayerHit(int damage)
    {
        if (isInvulnarable) return;
        Debug.Log("Player is not Incible");
        Debug.Log(damage);
        {
            //Current Health decreases by attack amount
            CurrentHealth -= damage;
            FMOD.Studio.EventInstance playerHurtSound;
            playerHurtSound = FMODUnity.RuntimeManager.CreateInstance("event:/playerHurt");
            playerHurtSound.start();
            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                //Death Animation and Sound Plays here
                musicSystem.endMusic();
                Debug.Log("PlayerHastDied");
                StartCoroutine(restart());
                return;
            }

            StartCoroutine(Iframes());
        }
    }
    private IEnumerator restart(){
        gameOverText.text = "GAME OVER";
        //wait 10 seconds
        yield return new WaitForSeconds(10);
        //now restart the scene
        musicSystem.stopMusic();
        SceneManager.LoadScene("SampleScene");
    }
    private void ScaleModelTo(Vector3 scale)
    {
        model.transform.localScale = scale;
    }
    
    private IEnumerator Iframes()
    {
        Debug.Log("Player turned invincible!");
        isInvulnarable = true;
        for (float i = 0; i < invincibilityDurationSeconds; i += invincibilityDeltaTime)
        {
            // Alternate between 0 and 1 scale to simulate flashing
            if (model.transform.localScale == Vector3.one)
            {
                ph.speed = 6;
                ScaleModelTo(Vector3.zero);
            }
            else
            {
                ph.speed = 6;
                ScaleModelTo(Vector3.one);
            }
            yield return new WaitForSeconds(invincibilityDeltaTime);
        }

        isInvulnarable = false;
        ScaleModelTo(Vector3.one);
        ph.speed = 4;
        Debug.Log("Player is no longer invincible!");
    }
}