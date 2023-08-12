using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D col;

    public float diff;

    public float movementSpeed = 5f;
    public UnityEngine.Vector2 movement;

    private bool canDash = true;
    private bool isDashing;
    public float dashRange = 5f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    public UnityEngine.Vector2 mousePositionScreen;
    public UnityEngine.Vector2 mousePositionWorld;

    [SerializeField] private TrailRenderer tr;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
        rb = this.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame Dependent on Framerate = Bad 
    void Update()
    {
        mousePositionScreen = Input.mousePosition;
        mousePositionWorld = Camera.main.ScreenToWorldPoint(mousePositionScreen);
        diff = (mousePositionWorld - rb.position).magnitude;
        
        if(isDashing)
        {
            return;
        }
        

        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

       if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
       {
            StartCoroutine(MouseDash());
       }
    }

    //Called  50/sec by Default not tied to fps = good
    void FixedUpdate()
    {   
        if(isDashing)
        {
            return;
        }

        // Movement ermöglicht solange wie die Kollisionen aktiv sind
        if(col.enabled)
        {
            rb.velocity = new UnityEngine.Vector2(movement.x * movementSpeed, movement.y * movementSpeed);
        }
    }

    private IEnumerator MouseDash()
    {   
        UnityEngine.Vector2 staticMousePositionWorld = mousePositionWorld;
        UnityEngine.Vector2 staticDirection =  staticMousePositionWorld - rb.position;
        
        canDash = false;
        isDashing = true;

        if (dashRange >= staticDirection.magnitude)
        {
            rb.velocity = staticDirection / dashingTime;
        }
        else
        {
            rb.velocity = staticDirection.normalized * dashRange / dashingTime;
        }
        
        float originalRadius =  rb.GetComponent<CircleCollider2D>().radius;
        rb.GetComponent<CircleCollider2D>().radius = 0; 
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        rb.GetComponent<CircleCollider2D>().radius = originalRadius;
        tr.emitting = false;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
