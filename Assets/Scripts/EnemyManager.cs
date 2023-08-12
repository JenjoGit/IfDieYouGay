using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    public float minSpawnInterval = 2f;
    public float maxSpawnInterval = 2f;
    public Transform player;
    [SerializeField] float distance = 100f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());        
    }
    // Update is called once per frame Dependent on Framerate = Bad 
    void Update()
    {

    }
    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(spawnInterval);

            SpawnEnemy();
        }
    }
    void SpawnEnemy()
    {
        Vector3 spawnPosition = CalculateSpawnPosition();
        Instantiate(prefab, spawnPosition, Quaternion.identity);
    }

    Vector3 CalculateSpawnPosition()
    {
        float angle = Random.Range(0f, 360f);
        Vector3 offset = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0f) * distance;
        Vector3 spawnPos = player.position + offset;
        return spawnPos;
    }
}
