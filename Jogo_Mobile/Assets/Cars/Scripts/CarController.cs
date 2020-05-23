using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum CarState
{
    STANDARD,
    DELIVERING,
    CRASHED
}

public class CarController : MonoBehaviour
{
    private CarState state = new CarState();
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
        switch (state)
        {
            case CarState.STANDARD:

                if (Input.touchCount > 0)
                    Drive(Input.GetTouch(0).position);

                if (Input.GetMouseButton(0))
                    Drive(Input.mousePosition);

                if (Input.touchCount > 0 || Input.GetMouseButton(0))
                    rb.drag = 0;
                else
                    rb.drag = 2;

                if (!DetectRoad())
                {
                    state = CarState.CRASHED;
                    StartCoroutine(CrashDelay());
                }

                break;
        }
        
    }

    void Drive(Vector3 clickPos)
    {
        targetPos = mainCam.ScreenToWorldPoint(clickPos);
        print(transform.position + " : " + targetPos);

        velDir = (targetPos - transform.position);
        velDir.y = 0;
        velDir = velDir.normalized;
        print(velDir);


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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position + (transform.forward * roadCheckOffset), roadCheckRadius);
    }
}
