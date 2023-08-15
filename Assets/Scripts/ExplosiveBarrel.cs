using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
    Collider2D[] explosionCollider = null;

    [SerializeField] private float explosionRadius = 0f;
    [SerializeField] private float explosionForceMulti = 5;
    [SerializeField] private float explosionDamage = 25;

    [SerializeField] private AudioSource audioSource;

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
       GameObject other = col.gameObject;
        if(other.CompareTag("Player") && col.Equals(other.GetComponent<CircleCollider2D>()) && other.GetComponent<Movement>().isDashing)
        {
            Explode();
            
        }
    }

    //
    // Summary:
    //      Let the Barrel explode
    //
    public void Explode()
    {
        audioSource.Play();

        explosionCollider = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        
        

        foreach(Collider2D col in explosionCollider)
        {   
            GameObject other = col.gameObject;
            Rigidbody2D colRigidbody = other.GetComponent<Rigidbody2D>();

            if (other.CompareTag("Player") && col.Equals(other.GetComponent<CircleCollider2D>())) 
            {
                col.GetComponent<Health>().takeDamage(explosionDamage); 
            }
            else if (other.CompareTag("Enemy"))
            {
                col.GetComponent<Health>().takeDamage(explosionDamage); 
            }

            if(colRigidbody != null)
            {
                Debug.Log(col);
                Vector2 distanceVector = col.transform.position - transform.position;
                if(distanceVector.magnitude > 0)
                {
                    float explosionForce = explosionForceMulti / distanceVector.magnitude;
                    colRigidbody.AddForce(distanceVector.normalized * explosionForce);
                }
            }
            
            //  else if (other.CompareTag("Explosion"))
            //  {
            //      col.gameObject.GetComponent<ExplosiveBarrel>().Explode();
            //  }
        }
        Destroy(gameObject, 0.854f);
    }
    
    /// <summary>
    /// Callback to draw gizmos that are pickable and always drawn.
    /// </summary>
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
