using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform player;
    public float spawnRate = 2.0f;
    public float spawnDistance = 10.0f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 2.0f, spawnRate);
    }

    void SpawnEnemy()
    {
        Vector2 spawnDir = Random.insideUnitCircle.normalized * spawnDistance;
        Vector2 spawnPos = (Vector2)player.position + spawnDir;
        int rand = Random.Range(0, enemyPrefabs.Length);

        Instantiate(enemyPrefabs[rand], spawnPos, Quaternion.identity);
    }

    // stack
    // maps
    // arrays
    // lists
    // dictionaries
    // queues
}
