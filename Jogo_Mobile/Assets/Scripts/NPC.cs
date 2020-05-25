using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private Spawner mySpawner;
    private CarController player;
    private Animator anim;

    [HideInInspector]
    public bool received = false;

    public GameObject icon;
    public GameObject area;

    private void Start()
    {
        player = FindObjectOfType<CarController>();
        anim = GetComponent<Animator>();

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

        anim.SetBool("Received", received);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Deliver" && !received)
        {
            received = true;
            GameManager.manager.score++;
            icon.SetActive(false);
            area.SetActive(false);
        }
    }
}
