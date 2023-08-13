using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterMovement : MonoBehaviour
{
    [SerializeField] float speed  = 3f; 
    Rigidbody2D enemy_rb;
    Transform target;
    Vector2 moveDirection;
    [SerializeField] Health health;
    public float maxDistance = 10f;
    [SerializeField] private float explosionDamage = 30f;


    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        enemy_rb = GetComponent<Rigidbody2D>();
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
        if(target)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, target.position);
            if(distanceToPlayer > maxDistance)
                enemy_rb.velocity = speed * Time.deltaTime * new Vector2(moveDirection.x, moveDirection.y);
            else
                enemy_rb.velocity = Vector2.zero;
        }
    }
    // Update is called once per frame
    void Update()
    {

        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            float angle  = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            enemy_rb.rotation = angle;
            moveDirection = direction;
        }
    }
    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            health.takeDamage(2);
            if(health.currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Explosion"))
        {
            Debug.Log("Damage Taken");
            health.takeDamage(explosionDamage);
        }
    }
}
