using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    
    public float damage = 5;

    [SerializeField] private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 1)
        {
            timer = 0;
            shoot();
        }
    }
    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().parent = gameObject;
    }
}
