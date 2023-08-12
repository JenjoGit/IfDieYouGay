using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 5f;
    private Rigidbody2D rb;
    private Collider2D col;
    public Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
        rb = this.GetComponent<Rigidbody2D>();

    }
    // Update is called once per frame Dependent on Framerate = Bad 
    void Update()
    {
       // Input 
       movement.x = Input.GetAxisRaw("Horizontal");
       movement.y = Input.GetAxisRaw("Vertical");
    }

    //Called  50/sec by Default not tied to fps = good
    void FixedUpdate()
    {
        // Movement ermöglicht solange wie die Kollisionen aktiv sind
        if(col.enabled)
        {
            rb.MovePosition(rb.position + movementSpeed * Time.fixedDeltaTime * movement);
        }
    }
}
