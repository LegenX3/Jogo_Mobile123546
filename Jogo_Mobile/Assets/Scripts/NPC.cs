using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private Spawner mySpawner;
    private MeshRenderer render;
    private CarController player;

    [HideInInspector]
    public bool received = false;

    public GameObject icon;

    private void Start()
    {
        player = FindObjectOfType<CarController>();

        mySpawner = transform.root.GetComponent<Spawner>();

        gameObject.SetActive(false);
    }

    private void Update()
    {
        if(received && Vector3.Distance(transform.position, player.transform.position) > 10)
        {
            if (mySpawner != null)
                mySpawner.spawnedPoints.Remove(this);
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Deliver" && !received)
        {
            received = true;
            GameManager.score++;
            icon.SetActive(false);
        }
    }
}
