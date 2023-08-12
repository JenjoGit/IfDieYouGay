using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello");
    }
    // Update is called once per frame Dependent on Framerate = Bad 
    void Update()
    {

    }
    //Called  50/sec by Default not tied to fps = good
    void FixedUpdate()
    {

    }
}
