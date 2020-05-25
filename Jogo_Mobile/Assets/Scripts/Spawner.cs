using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private List<NPC> npcs = new List<NPC>();
    [SerializeField]
    private float spawnRate = 10;

    private NPC lastSpawn = null;

    [HideInInspector]
    public List<NPC> spawnedPoints = new List<NPC>();

    void Start()
    {
        InvokeRepeating("Spawn", 0, spawnRate);
    }

    private void Spawn()
    {
        if (npcs.Count == spawnedPoints.Count)
            return;

        NPC currentSpawn = lastSpawn;

        if (spawnedPoints.Count == 0)
            currentSpawn = npcs[Random.Range(0, npcs.Count)];
        else
            while (spawnedPoints.Contains(currentSpawn) || currentSpawn == lastSpawn) { currentSpawn = npcs[Random.Range(0, npcs.Count)]; }

        lastSpawn = currentSpawn;
        spawnedPoints.Add(lastSpawn);

        currentSpawn.received = false;
        currentSpawn.gameObject.SetActive(true);
        currentSpawn.icon.SetActive(true);
        currentSpawn.area.SetActive(true);
    }
}
