using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Asteroids
{
    public class RadialSpawner : MonoBehaviour
    {
        [SerializeField] private float minRadius;
        [SerializeField] private float maxRadius;
        [SerializeField] private float spawnTimer;
        [SerializeField] private GameObject prefab;
        [SerializeField] private AnimationCurve scaleCurve;
        [SerializeField] private float maxSize;
        [SerializeField] private float minSize;

        private float _timer;

        private void Start()
        {
            _timer = spawnTimer;
        }
        
        private void Update()
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                _timer = spawnTimer;
                Spawn();
            }
        }
        
        private void Spawn()
        {
            var radius = Random.Range(minRadius, maxRadius);
            var angle = Random.Range(0, 360);
            var position = new Vector3(radius * Mathf.Cos(angle), 0, radius * Mathf.Sin(angle)) + transform.position;
            GameObject asteroid = Instantiate(prefab, position, Quaternion.identity, transform) as GameObject;

            float evaluatedScaleCurve = scaleCurve.Evaluate(Random.Range(0f, 1f));
            float scale = minSize + ((maxSize - minSize) * evaluatedScaleCurve);
            asteroid.transform.localScale = new Vector3(scale, scale, scale);

            CelestialBody celestialBody = asteroid.GetComponent<CelestialBody>();

            float scaledMass = celestialBody.rb.mass * scale;

            var angleOfTarget = Random.Range(0, 360);
            var targetPosition = new Vector3(radius * Mathf.Cos(angleOfTarget), 0, radius * Mathf.Sin(angleOfTarget)) + transform.position;

            var initialVelocity = Random.Range(1f, 10f) * (targetPosition - position).normalized;
            celestialBody.Initialize(scaledMass, initialVelocity);

            TrailRenderer trail = asteroid.GetComponentInChildren<TrailRenderer>();
            trail.startWidth = evaluatedScaleCurve;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(transform.position, minRadius);
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, maxRadius);
        }
    }
}
