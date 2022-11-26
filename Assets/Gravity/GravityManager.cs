using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour
{
    public float gravitationalConstant = 6.6743f;
    public float physicsTimeStep = 0.02f;
    private List<CelestialBody> bodies = new List<CelestialBody>();
    public static GravityManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        Time.fixedDeltaTime = physicsTimeStep;
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < bodies.Count; i++)
        {
            bodies[i].UpdateVelocity(bodies, gravitationalConstant, physicsTimeStep);
        }
    }

    public void AddCelestialBody(CelestialBody celestialBody)
    {
        bodies.Add(celestialBody);
    }

    public void RemoveCelestialBody(CelestialBody celestial)
    {
        bodies.Remove(celestial);
    }
}
