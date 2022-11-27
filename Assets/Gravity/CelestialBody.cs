using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialBody : MonoBehaviour
{
    [SerializeField] private Vector3 initialVelocity;
    [SerializeField] private float planetLaunchFactor = 100f;
    [SerializeField] private int boomThreshold = 100000;
    [SerializeField] private bool isPlanet = false;
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
                Vector3 acceleration = force / rb.mass;
                rb.velocity += acceleration * timeStep;
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
        GameObject effectInstance = null;

        Rigidbody rigidbody = collision.rigidbody;

        if (effect != null)
            effectInstance = Instantiate(effect, collision.contacts[0].point, Quaternion.identity);

        bool collisionIsPlanet = rigidbody.GetComponent<CelestialBody>().isPlanet;
        if (collisionIsPlanet)
        {
            Vector3 collisionDir = (collision.contacts[0].point - rb.position).normalized;
            Vector3 collisionForce = collisionDir * rb.velocity.magnitude * Mathf.Pow(rb.mass, 2f) * planetLaunchFactor;

            effectInstance.transform.localScale = effectInstance.transform.localScale * collisionForce.magnitude /  50000;

            if (collisionForce.magnitude > boomThreshold)
            {
                HitStopManager.Instance.HitStop(0.12f);
            }
            collision.rigidbody.AddForce(collisionForce);
            HitStopManager.Instance.HitStop(0.08f);
            Destroy(rb.gameObject);
        } else
        {
            rb.AddForce(rigidbody.velocity * rigidbody.mass);
        }
    }
}
