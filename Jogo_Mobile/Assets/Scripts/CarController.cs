﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public enum CarState
{
    STANDARD,
    CRASHED
}

public class CarController : MonoBehaviour
{
    public CarState state = new CarState();

    private Vector3 targetPos;
    private Vector3 velDir;
    private Camera mainCam;
    private Rigidbody rb;

    [SerializeField]
    private float spd = 0;
    [SerializeField]
    private float crashForce = 10;

    [SerializeField]
    private float roadCheckOffset = 0;
    [SerializeField]
    private float roadCheckRadius = 0;
    [SerializeField]
    private LayerMask roadCheckMask = new LayerMask();


    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.manager.state == GameState.PLAYING)
        {
            switch (state)
            {
                case CarState.STANDARD:

                    if (Input.touchCount > 0 && !IsPointerOverUIObject(Input.GetTouch(0)))
                    {
                        Drive(Input.GetTouch(0).position);
                    }                      

                    if (Input.touchCount > 0)
                        rb.drag = 0;
                    else
                        rb.drag = 4;

                    if (!DetectRoad())
                    {
                        state = CarState.CRASHED;
                        StartCoroutine(CrashDelay());
                    }

                    break;
            }
        }
        else
            rb.drag = 4;
    }

    void Drive(Vector3 clickPos)
    {
        targetPos = mainCam.ScreenToWorldPoint(clickPos);

        velDir = (targetPos - transform.position);
        velDir.y = 0;
        velDir = velDir.normalized;

        transform.forward = Vector3.Lerp(transform.forward, velDir, 10f * Time.deltaTime);
        rb.velocity = transform.forward * spd;
        transform.forward = new Vector3(rb.velocity.x, 0, rb.velocity.z).normalized;
    }

    bool DetectRoad()
    {
        return Physics.CheckSphere(transform.position + (transform.forward * roadCheckOffset), roadCheckRadius, roadCheckMask);
    }

    IEnumerator CrashDelay()
    {
        rb.velocity = Vector3.zero;
        rb.drag = 0;
        rb.AddForce(-transform.forward * crashForce, ForceMode.Impulse);

        yield return new WaitForSeconds(.5f);

        state = CarState.STANDARD;
    }

    private bool IsPointerOverUIObject(Touch input)
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(input.position.x, input.position.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position + (transform.forward * roadCheckOffset), roadCheckRadius);
    }
}
