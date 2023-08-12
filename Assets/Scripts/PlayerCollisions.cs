using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] Health health;
    [SerializeField] private float damage = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1;
            health.currentHealth = health.maxHealth;
        }
    }
    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Enemy"))
        {
            health.takeDamage(damage);
            
            if(health.currentHealth <= 0)
            {       
                
                Time.timeScale = 0;
            }
        }
        if(col.gameObject.CompareTag("Bullet"))
        {
            StartCoroutine(ExecuteAfterTime(0.1f, col));
        }

    }
    IEnumerator ExecuteAfterTime(float time, Collision2D col)
    {
        yield return new WaitForSeconds(time);
                Destroy(col.gameObject);

        // Code to execute after the delay
    }
}
