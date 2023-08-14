using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class PlayerCollisions : MonoBehaviour
{
    [SerializeField] Health health;
    [SerializeField] private Slider healthbar;



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
        healthbar.value = health.currentHealth / health.maxHealth * 100f;

    }
}
