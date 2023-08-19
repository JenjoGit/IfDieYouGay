using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChargeMovement : MonoBehaviour
{
    [SerializeField] float speed  = 80f; 
    
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;

    [SerializeField] float damage = 30;
    [SerializeField] float knockback = 5;

    public float minDistance = 5f;

    private bool isCharging = false;
    private bool canCharge = true;
    private bool hitSomething = false;
    [SerializeField] private float chargeSpeed = 160f;
    [SerializeField] private float maxChargeRange = 40f;

    [SerializeField] AudioClip alerted;
    [SerializeField] AudioClip steps;
    [SerializeField] AudioSource source;

    [SerializeField] TrailRenderer tr;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

/// <summary>
/// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
/// </summary>
    void FixedUpdate()
    {
        if(isCharging)
        {
            return;
        }

        if(target)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, target.position);
            if(distanceToPlayer > minDistance)
                rb.velocity = speed * Time.deltaTime * moveDirection;
            else if (canCharge)
                StartCoroutine(Charge());
        }
    }
    // Update is called once per frame
    void Update()
    {
        //if(isCharging)
        //{
        //    return;
        //}

        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            float angle  = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle - 90 ;
            moveDirection = direction;
        }
    }

    private IEnumerator Charge()
    {
        canCharge = false;
        isCharging = true;
        tr.emitting = true;
        rb.velocity = Vector2.zero;
        Vector2 startPosition = rb.position;
        Vector2 chargeDirection = moveDirection;
        source.clip = alerted;
        source.Play();
        
        yield return new WaitForSeconds(1f);

        rb.velocity = chargeSpeed * Time.deltaTime * chargeDirection;

        while((rb.position - startPosition).magnitude < maxChargeRange && !hitSomething)
        {
            source.clip = steps;
            source.Play();
            yield return new WaitForSeconds(0.25f);
        }

        rb.velocity = Vector2.zero;

        isCharging = false;
        tr.emitting = false;
        yield return new WaitForSeconds(2f);
        canCharge = true;
        hitSomething = false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        GameObject other = col.gameObject;
        if(other.CompareTag("Player")) // && col.Equals(other.GetComponent<CircleCollider2D>()))
        {
            Debug.Log("Player hit");
            other.GetComponent<Health>().takeDamage(damage);
            other.GetComponent<Rigidbody2D>().AddForce((other.transform.position - transform.position).normalized * knockback);
            hitSomething = true;
            
        }
        else if(other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy hit");
            other.GetComponent<Health>().takeDamage(damage);
            other.GetComponent<Rigidbody2D>().AddForce((other.transform.position - transform.position).normalized * knockback);
            hitSomething = true;
            
        }
        else if (other.CompareTag("Explosion"))
        {
            other.GetComponent<ExplosiveBarrel>().Explode();
            hitSomething = true;
        }
        
    }
}
