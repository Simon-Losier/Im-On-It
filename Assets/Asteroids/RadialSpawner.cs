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
            Instantiate(prefab, position, Quaternion.identity, transform);
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
