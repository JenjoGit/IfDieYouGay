using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed  = 3f; 
    Rigidbody2D enemy_rb;
    Transform target;
    Vector2 moveDirection;

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
        target = GameObject.FindWithTag("Player").transform;
    }

/// <summary>
/// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
/// </summary>
    void FixedUpdate()
    {
        if(target)
        {
            enemy_rb.velocity = speed * Time.deltaTime * new Vector2(moveDirection.x, moveDirection.y);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            float angle  = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            enemy_rb.rotation = angle;
            moveDirection = direction;
        }
    }
}
