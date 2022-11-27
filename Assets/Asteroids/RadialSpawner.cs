using System;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

namespace Asteroids
{
    public class RadialSpawner : MonoBehaviour
    {
        [Header("Object settings")]
        [SerializeField] private GameObject prefab;
        [SerializeField] private AnimationCurve scaleCurve;
        [SerializeField] private float maxSize;
        [SerializeField] private float minSize;
        
        [Header("Spawn Area")]
        [SerializeField] private float minRadius;
        [SerializeField] private float maxRadius;
        
        [Header("Difficulty")]
        [SerializeField] private float firstSpawnTimer;
        [SerializeField] private float minSpawnTimer;
        [SerializeField] private float maxSpawnTimer;
        [SerializeField] private AnimationCurve spawnTimerCurve;
        [SerializeField] private float timeUntilMaxSpawnTimer;

        private float _initialSpawnTimer;
        private float _spawnTimer;
        private float _timer;

        private void Start()
        {
            _initialSpawnTimer = firstSpawnTimer;
            _timer = 0f;
            _spawnTimer = minSpawnTimer;
        }
        
        private void Update()
        {
            if (_initialSpawnTimer > 0)
            {
                _initialSpawnTimer -= Time.deltaTime;
                return;
            }
            _timer += Time.deltaTime;
            _spawnTimer -= Time.deltaTime;

            if (_spawnTimer <= 0)
            {
                _spawnTimer = spawnTimerCurve.Evaluate(_timer/timeUntilMaxSpawnTimer) * (maxSpawnTimer - minSpawnTimer) + minSpawnTimer;
                Spawn();
            }
        }
        
        private void Spawn()
        {
            Debug.Log("Spawning a thing");
            var radius = Random.Range(minRadius, maxRadius);
            var angle = Random.Range(0, 360);
            var position = new Vector3(radius * Mathf.Cos(angle), 0, radius * Mathf.Sin(angle)) + transform.position;

            InitializeAsteroid(radius, angle, position);
        }
        
        private void InitializeAsteroid(float radius, float angle, Vector3 position)
        {
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
