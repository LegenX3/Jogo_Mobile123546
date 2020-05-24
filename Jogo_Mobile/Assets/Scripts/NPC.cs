using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private Spawner mySpawner;
    private bool received = false;

    private void Start()
    {
        mySpawner = transform.root.GetComponent<Spawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Deliver" && !received)
        {
            received = true;
            GameManager.score++;

            if (mySpawner != null)
                mySpawner.spawnedPoints.Remove(transform.parent);
            Destroy(gameObject);
        }
    }
}
