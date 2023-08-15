using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float maxHealth = 100.0f;
    public float currentHealth;

    public float baseRegen = 1.0f;
    public float armor = 0;
    
    [SerializeField] private Slider healthbar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth < maxHealth)
            currentHealth += baseRegen * Time.deltaTime;
        else if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1;
            currentHealth = maxHealth;
        }
        if (gameObject.CompareTag("Player"))
        {
            healthbar.value = currentHealth / maxHealth * 100f;
        }
    }
    void FixedUpdate() 
    {
    }

    public void takeDamage(float damage)
    {
        currentHealth -= damage - (damage * armor /100);

        if(currentHealth <= 0)
        {
            die();
        }
    }

    private void die()
    {
        if(this.gameObject.CompareTag("Player")) 
        {
             Time.timeScale = 0;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
