using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval;
    private float nextSpawnInterval;

    // Start is called before the first frame update
    void Start()
    {
        nextSpawnInterval = spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        nextSpawnInterval -= Time.deltaTime;
        if (nextSpawnInterval > 0f) return;
        nextSpawnInterval = spawnInterval;

        Vector2 spawnLocation = 13f * Random.onUnitSphere;
        Instantiate(enemyPrefab, new Vector3(spawnLocation.x, 1.5f, spawnLocation.y), Quaternion.identity);
    }
}
