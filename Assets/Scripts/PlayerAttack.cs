using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PolygonCollider2D pC;
    public float playerDamage = 5;
    public float playerKnockback = 5;

    private bool canAttack = true;
    private bool isAttacking;
    [SerializeField] private float attackTime = 0.1f;
    [SerializeField] private float attackCooldown = 1f;

    // Start is called before the first frame update
    void Start()
    {
        pC = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            StartCoroutine(Attack());
        }
    }
    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D col)
    {   
        GameObject other = col.gameObject;
        
        Debug.Log("should Attack");
        if(other.CompareTag("Enemy") && isAttacking)
        {
            Debug.Log("is Attacking");
            Rigidbody2D colRigidbody = other.GetComponent<Rigidbody2D>();
            Vector2 direction = col.transform.position - transform.position;
                if(direction.magnitude > 0)
                {
                    colRigidbody.AddForce(direction.normalized * playerKnockback);
                }
            other.GetComponent<Health>().takeDamage(playerDamage);
            // -------------------------
            // Knockback & Damage is Work in Progress
            // -------------------------
        }
        if(other.CompareTag("Explosion") && isAttacking)
        {
            col.gameObject.GetComponent<ExplosiveBarrel>().Explode();
        }
    }


    private IEnumerator Attack()
    {
        canAttack = false;
        isAttacking = true;

        
        
        yield return new WaitForSeconds(attackTime);

        isAttacking = false;

        yield return new WaitForSeconds(attackCooldown);

        canAttack = true;
    }
}
