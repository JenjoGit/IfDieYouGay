using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    public bool mouseEnabled;

    public Vector2 mousePositionScreen;
    public Vector2 mousePositionWorld;
    public float diff;

    public Vector2 direction;
    public double angle;

    public float movementSpeed = 5f;
    public Vector2 movement;

    private bool canDash = true;
    public bool isDashing;
    [SerializeField] private float dashRange = 5f;
    [SerializeField] private float dashingTime = 0.2f;
    [SerializeField] private float dashingCooldown = 1f;

    

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
            angle = Vector2.Angle(Vector2.up, direction);
                if (mousePositionWorld.x > rb.position.x)
                {
                    angle = -angle;
                }  
        }
        else
        {
            direction = rb.velocity;
            angle = Vector2.Angle(Vector2.up, direction);
            if (direction.x > 0)
                {
                    angle = -angle;
                }
        }

        
        transform.eulerAngles = new Vector3(0, 0, (float) angle);
        

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
            rb.velocity = new Vector2(movement.x * movementSpeed, movement.y * movementSpeed);
        }
    }

    /// <summary>
    /// Dashes either towards Mousedirection,
    ///          - has MaxRange, can dash shorter
    ///      or in direction of movement
    ///          - allways MaxRange
    private IEnumerator Dash(Vector2 dir)
    {   
        canDash = false;
        isDashing = true;

        if(mouseEnabled)
        {
            rb.velocity = Vector2.ClampMagnitude(dir, dashRange) / dashingTime;
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
