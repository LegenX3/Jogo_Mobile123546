using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePlus : MonoBehaviour
{

    private ItemSpawner mySpawner;

    private void Start()
    {
        mySpawner = transform.root.GetComponent<ItemSpawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameManager.manager.timer += 10;
            if (mySpawner != null)
                mySpawner.spawnedPoints.Remove(gameObject);
            gameObject.SetActive(false);
        }
    }
}
