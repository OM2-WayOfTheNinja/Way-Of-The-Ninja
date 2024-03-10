using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarShootMover : MonoBehaviour
{
   
    [SerializeField] float forceSize = 100f;
    [SerializeField] ForceMode forceMode = ForceMode.Force;
    [SerializeField] float torqueSize = 100f;
    [SerializeField] ForceMode torqueMode = ForceMode.Force;

    [SerializeField] GameObject crossHair;

    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //shoots the ninja star towards the player's position
        Vector3 dir = crossHair.transform.position - transform.position;
        dir = dir.normalized;
        rb.AddForce(dir * forceSize, forceMode);
        Vector3 rotationAngle = new Vector3(0, 1, 0); 
        rb.AddTorque(rotationAngle * torqueSize, torqueMode);
    }
}
