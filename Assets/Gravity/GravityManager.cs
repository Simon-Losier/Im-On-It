using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Universe;

public class GravityManager : MonoBehaviour
{
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

        Time.fixedDeltaTime = UniversalConstants.physicsTimeStep;
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < bodies.Count; i++)
        {
            bodies[i].UpdateVelocity(bodies, UniversalConstants.physicsTimeStep);
        }

        for (int i = 0; i < bodies.Count; i++)
        {
            bodies[i].UpdatePosition(UniversalConstants.physicsTimeStep);
        }
    }

    public void AddCelestialBody(CelestialBody celestialBody)
    {
        bodies.Add(celestialBody);
    }
}
