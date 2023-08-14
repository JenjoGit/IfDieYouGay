using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    public bool mouseEnabled;

    public UnityEngine.Vector2 mousePositionScreen;
    public UnityEngine.Vector2 mousePositionWorld;
    public float diff;

    public UnityEngine.Vector2 direction;
    public double angle;

    public float movementSpeed = 5f;
    public UnityEngine.Vector2 movement;

    private bool canDash = true;
    private bool isDashing;
    public float dashRange = 5f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Collider2D col;
    [SerializeField] private TrailRenderer tr;

    // Start is called before the first frame update
    void Start()
    {
        mouseEnabled = true;
    }

    // Update is called once per frame Dependent on Framerate = Bad 
    void Update()
    {   
        if (mouseEnabled)
        {
            mousePositionScreen = Input.mousePosition;
            mousePositionWorld = Camera.main.ScreenToWorldPoint(mousePositionScreen);
            diff = (mousePositionWorld - rb.position).magnitude;
            direction = (mousePositionWorld - rb.position);
            angle = UnityEngine.Vector2.Angle(UnityEngine.Vector2.up, direction);
                if (mousePositionWorld.x > rb.position.x)
                {
                    angle = -angle;
                }  
        }
        else
        {
            direction = rb.velocity;
            angle = UnityEngine.Vector2.Angle(UnityEngine.Vector2.up, direction);
            if (direction.x > 0)
                {
                    angle = -angle;
                }
        }

        
        transform.eulerAngles = new UnityEngine.Vector3(0, 0, (float) angle);
        

        if(isDashing)
        {
            return;
        }
        

        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

       if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
       {
            StartCoroutine(Dash(direction));
       }

       if (Input.GetMouseButtonDown(3))
       {
            mouseEnabled = !mouseEnabled;
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
    //      Dashes either towards Mousedirection,
    //          - has MaxRange, can dash shorter
    //      or in direction of movement
    //          - allways MaxRange
    private IEnumerator Dash(UnityEngine.Vector2 dir)
    {   
        canDash = false;
        isDashing = true;

        if(mouseEnabled)
        {
            rb.velocity = UnityEngine.Vector2.ClampMagnitude(dir, dashRange) / dashingTime;
        }
        else
        {
            rb.velocity = movement.normalized * dashRange / dashingTime;
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
