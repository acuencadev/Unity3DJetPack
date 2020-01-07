using UnityEngine;

public class SimpleSpawner : MonoBehaviour
{
    [SerializeField]
    private SimplePrefabPool pool;

    [SerializeField]
    private Transform parent;

    [SerializeField]
    [Range(0f, 100f)]
    private float minSpawnRate;

    [SerializeField]
    [Range(0f, 100f)]
    private float maxSpawnRate;

    [SerializeField]
    private float minSpawnY;

    [SerializeField]
    private float maxSpawnY;

    private float spawnRate;
    private float nextSpawnRate;

    private void Start()
    {
        SetRandomSpawnRate();
    }

    private void Update()
    {
        if (ShouldSpawn())
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        SetRandomSpawnRate();
        nextSpawnRate = Time.time + spawnRate;

        float yPosition = Random.Range(minSpawnY, maxSpawnY);
        Vector3 spawnPosition = new Vector3(transform.position.x, yPosition, 0f);

        if (pool.HasItemsAvailable())
        {
            pool.GetItem(spawnPosition, transform.rotation, parent);
        }
    }

    private void SetRandomSpawnRate()
    {
        spawnRate = Random.Range(minSpawnRate, maxSpawnRate);
    }

    private bool ShouldSpawn()
    {
        return Time.time >= nextSpawnRate;
    }
}
