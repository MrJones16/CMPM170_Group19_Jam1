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


    void Start()
    {
        CurrentHealth = MaxHealth;
        isInvulnarable = false;
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
                // Broadcast some sort of death event here before returning
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
                ScaleModelTo(Vector3.zero);
            }
            else
            {
                ScaleModelTo(Vector3.one);
            }
            yield return new WaitForSeconds(invincibilityDeltaTime);
        }

        isInvulnarable = false;
        ScaleModelTo(Vector3.one);
        Debug.Log("Player is no longer invincible!");
    }
}