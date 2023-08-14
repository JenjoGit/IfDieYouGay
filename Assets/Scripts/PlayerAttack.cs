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
    private float attackTime = 0.1f;
    private float attackCooldown = 1f;

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
        if(col.gameObject.CompareTag("Enemy") && isAttacking)
        {
            // col.gameObject.GetComponent<Health>().takeDamage(playerDamage);
            
            //col.gameObject.GetComponent<Rigidbody2D>().

            // -------------------------
            // Knockback & Damage is Work in Progress
            // -------------------------
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
