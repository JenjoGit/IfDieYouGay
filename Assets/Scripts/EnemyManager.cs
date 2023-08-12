using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject prefab; 
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello");
        // for(int i = 0; i <= 10; i++)
        // {
        //     Instantiate(prefab, new Vector2(i, i), Quaternion.identity);
        // }
        
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
