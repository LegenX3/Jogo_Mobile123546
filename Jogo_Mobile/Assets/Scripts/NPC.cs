using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{

    private bool received = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Deliver" && !received)
        {
            received = true;
            GameManager.score++;

            gameObject.SetActive(false);
        }
    }
}
