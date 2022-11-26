using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Asteroids
{
    public class RadialSpawner : MonoBehaviour
    {
        [SerializeField] private float minRadius;
        [SerializeField] private float maxRadius;
        [SerializeField] private float spawnRate;
        [SerializeField] private GameObject prefab;

        private float _timer;

        private void Start()
        {
            _timer = spawnRate;
        }
        
        private void Update()
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                _timer = spawnRate;
                Spawn();
            }
        }
        
        private void Spawn()
        {
            var radius = Random.Range(minRadius, maxRadius);
            var angle = Random.Range(0, 360);
            var position = new Vector3(radius * Mathf.Cos(angle), radius * Mathf.Sin(angle), 0);
            Instantiate(prefab, position, Quaternion.identity);
        }
    }
}
