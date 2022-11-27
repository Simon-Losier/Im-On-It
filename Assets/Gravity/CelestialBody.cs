using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialBody : MonoBehaviour
{
    [SerializeField] private Vector3 initialVelocity;
    [SerializeField] private bool isPlanet;
    [SerializeField] private GameObject effect;

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

    private void OnCollisionEnter(Collision collision)
    {
        Collision(collision);
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

    private void Collision(Collision collision)
    {
        Rigidbody rigidbody = collision.rigidbody;
        Instantiate(effect, collision.contacts[0].point, Quaternion.identity);

        bool collisionIsPlanet = rigidbody.GetComponent<CelestialBody>().isPlanet;

        rb.AddForce(rigidbody.velocity * rigidbody.mass);
        
        if (collisionIsPlanet)
        {
            Destroy(rb.gameObject);
        }
    }
}
