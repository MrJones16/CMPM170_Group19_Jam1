using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private PC ph;

    void Start()
    {
        CurrentHealth = MaxHealth;
        isInvulnarable = false;
        ph = gameObject.GetComponent<PC>();
    }

    public void PlayerHit(int damage)
    {
        if (isInvulnarable) return;
        Debug.Log("Player is not Incible");
        Debug.Log(damage);
        {
            //Current Health decreases by attack amount
            CurrentHealth -= damage;
            
            
            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                //Death Animation and Sound Plays here
                musicSystem.endMusic();
                Debug.Log("PlayerHastDied");
                return;
            }

            StartCoroutine(Iframes());
        }
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
                ph.speed = 100000;
                ScaleModelTo(Vector3.zero);
            }
            else
            {
                ph.speed = 10;
                ScaleModelTo(Vector3.one);
            }
            yield return new WaitForSeconds(invincibilityDeltaTime);
        }

        isInvulnarable = false;
        ScaleModelTo(Vector3.one);
        ph.speed = 10;
        Debug.Log("Player is no longer invincible!");
    }
}