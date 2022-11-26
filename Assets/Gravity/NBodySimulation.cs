using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Universe;

public class NBodySimulation : MonoBehaviour
{
    CelestialBody[] bodies;

    private void Awake()
    {
        bodies = FindObjectsOfType<CelestialBody>();
        Time.fixedDeltaTime = UniversalConstants.physicsTimeStep;
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < bodies.Length; i++)
        {
            bodies[i].UpdateVelocity(bodies, UniversalConstants.physicsTimeStep);
        }

        for (int i = 0; i < bodies.Length; i++)
        {
            bodies[i].UpdatePosition(UniversalConstants.physicsTimeStep);
        }
    }
}
