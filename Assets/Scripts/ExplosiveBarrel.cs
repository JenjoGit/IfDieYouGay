using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
    [SerializeField] private float explosionRadius = 0f;
    Collider2D[] explosionCollider = null;
    [SerializeField] private float explosionForceMulti = 5;
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
            Debug.Log("Explode");
        }
    }
    void Explode()
    {
        Debug.Log("Explode");
        explosionCollider = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach(Collider2D col in explosionCollider)
        {
            Rigidbody2D colRigidbody = col.GetComponent<Rigidbody2D>();
            if(colRigidbody != null)
            {
                Vector2 distanceVector = col.transform.position - transform.position;
                if(distanceVector.magnitude > 0)
                {
                    float explosionForce = explosionForceMulti / distanceVector.magnitude;
                    colRigidbody.AddForce(distanceVector.normalized * explosionForce);
                }
            }
        }
    }
    /// <summary>
    /// Callback to draw gizmos that are pickable and always drawn.
    /// </summary>
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
