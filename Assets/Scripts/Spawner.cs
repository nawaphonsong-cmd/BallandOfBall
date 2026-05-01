using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab; // Drag your wall/obstacle prefab here
    public float spawnRate = 2f;      // Seconds between spawns
    private float timer = 0f;

    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnObstacle();
            timer = 0;
        }
    }

    void SpawnObstacle()
    {
        // Spawn at the spawner's position with a random height (Y)
        float spawnY = Random.Range(-4f, 4f);
        Instantiate(obstaclePrefab, new Vector3(transform.position.x, spawnY, 0), Quaternion.identity);
    }
}