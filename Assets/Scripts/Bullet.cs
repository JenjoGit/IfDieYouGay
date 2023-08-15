using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rb;

    [SerializeField] public GameObject parent;
    [SerializeField] private float damage;
    [SerializeField] private float speed = 0f;

    [SerializeField] AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {   
        damage = parent.GetComponent<EnemyShooter>().damage;

        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * speed; 
        float angle  = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + 90);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// aka. if the bullet hits something
    /// </summary>
    /// <param name="col">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject other = col.gameObject;

        if (other.CompareTag("Player") && col.Equals(other.GetComponent<CircleCollider2D>()))
        {
            PlaySound();
            col.gameObject.GetComponent<Health>().takeDamage(damage);
            StartCoroutine(ExecuteAfterTime(0.1f));
        }
        else if (other.CompareTag("Enemy") && !other.Equals(parent))
        {
            col.gameObject.GetComponent<Health>().takeDamage(damage);
            StartCoroutine(ExecuteAfterTime(0.1f));
        }
        else if (other.CompareTag("Explosion"))
        {
            col.gameObject.GetComponent<ExplosiveBarrel>().StartCoroutine(col.gameObject.GetComponent<ExplosiveBarrel>().Explode());
            StartCoroutine(ExecuteAfterTime(0.1f));
        }
    }
    void PlaySound()
    {
        if(!audioSource.isPlaying)
            {
                audioSource.Play();
            }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);

        // Code to execute after the delay
    }

    /// <summary>
    /// OnBecameInvisible is called when the renderer is no longer visible by any camera.
    /// </summary>
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
