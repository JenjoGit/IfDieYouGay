using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
    // [SerializeField] private ExplosionRadius
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="col">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            Explode();
        }
    }
    void Explode()
    {
        
    }
}
