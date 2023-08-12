using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100.0f;
    public float currentHealth; 

    public float baseRegen = 0.5f;
    public float armor = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate() 
    {
        if (currentHealth < maxHealth) {
            currentHealth += baseRegen;
        }
    }

    void takeDamage(float damage)
    {
        currentHealth -= damage * armor /100; // hallo
    
    }
}
