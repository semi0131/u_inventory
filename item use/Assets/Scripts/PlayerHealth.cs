using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;  

    public int maxHealth = 100;
    public int currentHealth = 0; 

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public bool Heal(int amount)
    {
        if (currentHealth >= maxHealth)
            return false; 

        currentHealth += amount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        Debug.Log("Player HP: " + currentHealth);
        return true; 
    }
}
