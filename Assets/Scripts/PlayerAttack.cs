using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PolygonCollider2D pC;

    private bool canAttack = true;

    // Start is called before the first frame update
    void Start()
    {
        pC = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //StartCoroutine(Attack());
        }
    }
    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D col)
    {
        
    }


    private IEnumerator Attack(UnityEngine.Vector2 direction)
    {

        
        yield return new WaitForSeconds(0.1f);



        yield return new WaitForSeconds(1);


    }
}
