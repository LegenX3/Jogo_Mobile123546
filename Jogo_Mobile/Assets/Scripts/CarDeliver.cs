using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDeliver : MonoBehaviour
{

    private CarController controller;

    [SerializeField]
    private GameObject delivery = null;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CarController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Objective")
        {
            Deliver delivered = Instantiate(delivery, transform.position, Quaternion.identity).GetComponent<Deliver>();
            delivered.startPos = transform.position;
            delivered.endPos = other.transform.parent.transform.position;
        }
    }
}
