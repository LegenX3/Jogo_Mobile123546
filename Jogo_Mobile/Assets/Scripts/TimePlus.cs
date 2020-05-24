using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePlus : MonoBehaviour
{

    private Spawner mySpawner;

    private void Start()
    {
        mySpawner = transform.root.GetComponent<Spawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameManager.timer = GameManager.timer + 10;
            if (mySpawner != null)
                mySpawner.spawnedPoints.Remove(transform);
            Destroy(gameObject);
        }
    }
}
