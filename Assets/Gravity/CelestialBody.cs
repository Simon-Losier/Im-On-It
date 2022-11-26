using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialBody : MonoBehaviour
{
    public Vector3 initialVelocity;

    public Rigidbody rb { get; private set; }
    private bool hasRigidbody;


    private void Awake()
    {
        hasRigidbody = true;
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            hasRigidbody = false;
        }
    }

    private void OnEnable()
    {
        GravityManager.Instance.AddCelestialBody(this);
        rb.velocity = initialVelocity;
    }

    private void OnDisable()
    {
        GravityManager.Instance.RemoveCelestialBody(this);
    }

    public void UpdateVelocity(List<CelestialBody> allBodies, float gravityConstant, float timeStep)
    {
        foreach (var otherBody in allBodies)
        {
            if (otherBody != this)
            {
                Vector3 delta = (otherBody.GetPosition() - this.GetPosition());
                float sqsrDst = delta.sqrMagnitude;
                Vector3 forceDir = delta.normalized;
                Vector3 force = forceDir * gravityConstant * rb.mass * otherBody.rb.mass / sqsrDst;
                Vector3 acceloration = force / rb.mass;
                rb.velocity += acceloration * timeStep;
            }
        }
    }

    private Vector3 GetPosition()
    {
        return (hasRigidbody) ? rb.position : transform.position;
    }

    public void Initialize(float mass, Vector3 initialVelocity)
    {
        rb.mass = mass;
        rb.velocity = initialVelocity;
    }
}
