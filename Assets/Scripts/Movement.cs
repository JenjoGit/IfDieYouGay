using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 5f;

    private Rigidbody2D rb;
    private Collider2D col;
    public UnityEngine.Vector2 movement;

    private bool canDash = true;
    private bool isDashing;
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

        // Movement ermöglicht solange wie die Kollisionen aktiv sind
        if(col.enabled)
        {
            rb.MovePosition(rb.position + movementSpeed * Time.fixedDeltaTime * movement);
        }
    }

    private IEnumerator MouseDash()
    {   
        UnityEngine.Vector2 staticMousePositionWorld = mousePositionWorld;
        UnityEngine.Vector2 staticDirection =  staticMousePositionWorld - rb.position;
        canDash = false;
        isDashing = true;
        //rb.velocity = new UnityEngine.Vector2(transform.localScale.x * dashingPower, transform.localScale.y * dashingPower);
        //rb.AddForce(staticDirection * dashingPower);
        rb.position = staticMousePositionWorld;
        Debug.Log("dashed");
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        Debug.Log("dashStoppt");
        tr.emitting = false;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        Debug.Log("dashCooldownVorbei");
        canDash = true;
    }

    void MouseDdash()
    {   
        //rb.position = rb.position + direction;
         
       // rb.AddForce(staticDirection * dashSpeed);

    }
}
