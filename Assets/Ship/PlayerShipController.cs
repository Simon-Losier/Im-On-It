using System;
using UnityEngine;

namespace Ship
{
    public class PlayerShipController : MonoBehaviour
    {
        [SerializeField] private float turnSpeed = 150f;
        private bool aKey;
        private bool dKey;

        private void Update() 
        {
            PlayerInput();
        }

        private void PlayerInput() 
        {
            aKey = Input.GetKey(KeyCode.A);
            dKey = Input.GetKey(KeyCode.D);
        }

        private void FixedUpdate()
        {
            
            if (aKey)
            {
                transform.Rotate(Vector3.up, -turnSpeed * Time.fixedDeltaTime);
            }

            if (dKey)
            {
                transform.Rotate(Vector3.up, turnSpeed * Time.fixedDeltaTime);
            }
        }
    }
}