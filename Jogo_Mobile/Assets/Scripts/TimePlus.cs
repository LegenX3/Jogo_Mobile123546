using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePlus : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameManager.timer = GameManager.timer + 10;
            Destroy(gameObject);
        }
    }
}
