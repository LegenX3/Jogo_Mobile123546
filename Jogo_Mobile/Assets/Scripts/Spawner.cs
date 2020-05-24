using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField]
    private GameObject spawnPrefab = null;
    [SerializeField]
    private List<Transform> spawnsPoints = new List<Transform>();
    [SerializeField]
    private float spawnRate = 10;

    private Transform lastSpawn = null;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 0, spawnRate);
    }

    private void Spawn()
    {
        Transform currentSpawn = lastSpawn;

        while (currentSpawn == lastSpawn) { currentSpawn = spawnsPoints[Random.Range(0, spawnsPoints.Count)]; }

        lastSpawn = currentSpawn;
        Instantiate(spawnPrefab, currentSpawn);
    }
}
