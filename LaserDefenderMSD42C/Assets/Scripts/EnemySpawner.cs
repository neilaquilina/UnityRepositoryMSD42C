using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform firstSpawnPoint;
    [SerializeField] int maximumEnemies = 10;
    [SerializeField] float spawnTime = 1.5f;

    int currentEnemies = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //coroutine to spawn an enemy (max 10) every 1.5 seconds
    IEnumerator SpawnEnemies()
    {
        while(currentEnemies <= maximumEnemies)
        {
            GameObject enemy = Instantiate(enemyPrefab, firstSpawnPoint.transform.position, transform.rotation);
            currentEnemies++;

            yield return new WaitForSeconds(spawnTime);
        }
    }
}
