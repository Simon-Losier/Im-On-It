using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Universe;

public class CelestialBody : MonoBehaviour
{
    public float mass;
    public float radius;
    public Vector3 initialVelocity;
    private Vector3 currentVelocity;

    private Rigidbody rb;
    private bool hasRigidbody;


    private void Awake()
    {
        currentVelocity = initialVelocity;

        hasRigidbody = true;
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            hasRigidbody = false;
        }
    }

    public void UpdateVelocity(CelestialBody[] allBodies, float timeStep)
    {
        foreach (var otherBody in allBodies)
        {
            if (otherBody != this)
            {
                Vector3 delta = (otherBody.GetPosition() - this.GetPosition());
                float sqsrDst = delta.sqrMagnitude;
                Vector3 forceDir = delta.normalized;
                Vector3 force = forceDir * UniversalConstants.gravitationalConstant * mass * otherBody.mass / sqsrDst;
                Vector3 acceloration = force / mass;
                currentVelocity += acceloration * timeStep;
            }
        }
    }

    public void UpdatePosition (float timeStep)
    {
        transform.position += currentVelocity * timeStep;
    }

    private Vector3 GetPosition()
    {
        return (hasRigidbody) ? rb.transform.position : transform.position;
    }
}
