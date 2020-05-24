using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> itemPoints = new List<GameObject>();
    [SerializeField]
    private float spawnRate = 10;

    private GameObject lastSpawn = null;

    [HideInInspector]
    public List<GameObject> spawnedPoints = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 0, spawnRate);
    }

    private void Spawn()
    {
        if (itemPoints.Count == spawnedPoints.Count)
            return;

        GameObject currentSpawn = lastSpawn;

        if (spawnedPoints.Count == 0)
            currentSpawn = itemPoints[Random.Range(0, itemPoints.Count)];
        else
            while (spawnedPoints.Contains(currentSpawn) || currentSpawn == lastSpawn) { currentSpawn = itemPoints[Random.Range(0, itemPoints.Count)]; }

        lastSpawn = currentSpawn;
        spawnedPoints.Add(lastSpawn);
        currentSpawn.gameObject.SetActive(true);
    }
}
