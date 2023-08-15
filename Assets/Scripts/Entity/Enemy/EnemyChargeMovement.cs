using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChargeMovement : MonoBehaviour
{
    [SerializeField] float speed  = 80f; 
    
    Rigidbody2D enemy_rb;
    Transform target;
    Vector2 moveDirection;

    public float minDistance = 10f;

    private bool isCharging = false;
    [SerializeField] private float chargeSpeed = 160f;
    [SerializeField] private float maxChargeRange = 40f;

    [SerializeField] AudioClip alerted;
    [SerializeField] AudioClip steps;
    [SerializeField] AudioSource source;

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
        if(isCharging)
        {
            return;
        }

        if(target)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, target.position);
            if(distanceToPlayer > minDistance)
                enemy_rb.velocity = speed * Time.deltaTime * new Vector2(moveDirection.x, moveDirection.y);
            else
                StartCoroutine(Charge());
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(isCharging)
        {
            return;
        }

        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            float angle  = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            enemy_rb.rotation = angle;
            moveDirection = direction;
        }
    }

    private IEnumerator Charge()
    {
        isCharging = true;
        enemy_rb.velocity = Vector2.zero;
        Vector2 startPosition = enemy_rb.position;
        Vector3 chargeDirection = moveDirection;
        source.clip = alerted;
        source.Play();
        
        yield return new WaitForSeconds(1f);

        enemy_rb.velocity = chargeSpeed * Time.deltaTime * new Vector2(chargeDirection.x, chargeDirection.y);

        while((enemy_rb.position - startPosition).magnitude < maxChargeRange)
        {
            source.clip = steps;
            source.Play();
            yield return new WaitForSeconds(0.25f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            //collision.gameObject.GetComponent<Health>().takeDamage(damage);
            
        }

        
    }
}
