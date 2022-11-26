using System;
using UnityEngine;

namespace Ship
{
    public class PlayerShipController : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float speed = 125f;
        [SerializeField] private float turnSpeed = 150f;
        private bool wKey;
        private bool aKey;
        private bool dKey;

        private void Update() 
        {
            PlayerInput();
        }

        private void PlayerInput() 
        {
            aKey = Input.GetKey(KeyCode.A);
            wKey = Input.GetKey(KeyCode.W);
            dKey = Input.GetKey(KeyCode.D);
        }

        private void FixedUpdate()
        {
            if (wKey)
                Throttle(speed * Time.fixedDeltaTime);
            if (aKey)
            {
                transform.Rotate(Vector3.up, -turnSpeed * Time.fixedDeltaTime);
            }

            if (dKey)
            {
                transform.Rotate(Vector3.up, turnSpeed * Time.fixedDeltaTime);
            }
        }

        private void Throttle(float force)
        {
            rb.AddForce(force * transform.forward);
        }
    }
}