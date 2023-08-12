using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D col;

    public float movementSpeed = 5f;
    public UnityEngine.Vector2 movement;

    private bool canDash = true;
    private bool isDashing;
    public float dashRange = 5f;
    private float dashingPower = 24f;
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
        //UnityEngine.Vector2 staticMousePositionWorld = mousePositionWorld;
        //UnityEngine.Vector2 staticDirection =  staticMousePositionWorld - rb.position;
        
        canDash = false;
        isDashing = true;
        //rb.velocity = new UnityEngine.Vector2(transform.localScale.x * dashingPower, transform.localScale.y * dashingPower);
        //rb.AddForce(staticDirection * dashingPower);
        //UnityEngine.Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //mousePos.z = 0f;
        rb.velocity = new UnityEngine.Vector2(transform.localScale.x * dashingPower , transform.localScale.y * dashingPower );

        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    void MouseDdash()
    {   
        //rb.position = rb.position + direction;
         
       // rb.AddForce(staticDirection * dashSpeed);

    }
}
