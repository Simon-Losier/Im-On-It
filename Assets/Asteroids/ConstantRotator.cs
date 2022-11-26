using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Asteroids
{
    public class ConstantRotator : MonoBehaviour
    {
        [SerializeField] private bool useRandomAxis;
        [SerializeField] private Vector3 axis; // Only used when not random
        [SerializeField] private float minSpeed;
        [SerializeField] private float maxSpeed;

        private float _speed;
        
        private void Start()
        {
            if (useRandomAxis)
                axis = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            _speed = Random.Range(minSpeed, maxSpeed);
        }
        
        private void Update()
        {
            transform.Rotate(axis, _speed * Time.deltaTime);
        }
    }
}
