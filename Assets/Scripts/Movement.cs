using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    

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

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Collider2D col;
    [SerializeField] private TrailRenderer tr;

    // Start is called before the first frame update
    void Start()
    {
        
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
       if (Input.GetKeyDown(KeyCode.LeftControl) && canDash)
       {
            StartCoroutine(MoveDash());
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

    //
    //  Summary:
    //      Dashes towards the Mouse position
    //      - has max. dashrange, but dashes onto position if close enough
    private IEnumerator MouseDash()
    {   
        UnityEngine.Vector2 staticDirection =  mousePositionWorld - rb.position;
        
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

    //
    //  Summary:
    //      Dashes into the current movedirection
    //      - allways dashes max. dashrange
    private IEnumerator MoveDash()
    {   
        canDash = false;
        isDashing = true;

        rb.velocity = movement.normalized * dashRange / dashingTime;
        float originalRadius =  rb.GetComponent<CircleCollider2D>().radius;
        rb.GetComponent<CircleCollider2D>().enabled = false;
        tr.emitting = true;

        yield return new WaitForSeconds(dashingTime);

        rb.GetComponent<CircleCollider2D>().enabled = true;
        tr.emitting = false;
        isDashing = false;

        yield return new WaitForSeconds(dashingCooldown);

        canDash = true;
    }
}
