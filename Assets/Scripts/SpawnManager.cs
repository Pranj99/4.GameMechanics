using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public float spawnRange = 9;
    // Start is called before the first frame update
    public GameObject enemyPrefab;
    void Start()
    {
        
        Instantiate(enemyPrefab, GenerateRandomSpawnPosition(), enemyPrefab.transform.rotation);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 GenerateRandomSpawnPosition()
    {
        float randomPosX = Random.Range(-spawnRange, spawnRange);
        float randomPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(randomPosX, 0, randomPosZ);
        return randomPos;
    }
}
