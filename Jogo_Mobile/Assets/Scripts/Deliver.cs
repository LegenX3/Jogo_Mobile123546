using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deliver : MonoBehaviour
{

    public Vector3 startPos, endPos;

    private Vector3 travelDir;
    private float gravity = 29.43f, peakTime = .25f;
    private float startYVel, xVel;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        startYVel = gravity * peakTime;
        xVel = Vector3.Distance(startPos, endPos) / (peakTime * 2);

        travelDir = endPos - startPos;
        travelDir.y = 0;
        travelDir.Normalize();

        print("Y Velocity: " + startYVel + " X Velocity: " + xVel + " Travel Direction: " + travelDir);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(timer < peakTime * 2)
        {
            Vector3 pos = Vector3.zero;
            pos = travelDir * (xVel * timer);
            pos.y = (startYVel * timer) - ((gravity * Mathf.Pow(timer, 2)) / 2);

            transform.position = startPos + pos;

            timer += (Time.deltaTime % 60);

            print("current: " + transform.position + " start: " + startPos + " added: " + pos + " time: " + timer);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Deliver")
        {
            Destroy(gameObject);
        }
    }
}
