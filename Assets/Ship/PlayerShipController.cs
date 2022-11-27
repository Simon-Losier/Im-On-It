using System;
using UnityEngine;

namespace Ship
{
    public class PlayerShipController : MonoBehaviour
    {
        [SerializeField] private float turnSpeed;

        private void Update() 
        {
            PlayerInput();
        }

        private void PlayerInput() 
        {
            if (PlayerInputManager.Instance.ControlState == PlayerInputManager.ControlStates.RocketSteering)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
                }
                if (Input.GetKey(KeyCode.D))
                {
                    transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
                }   
            }
        }

        private void OnDestroy()
        {
            PlayerInputManager.Instance.SetControlState(PlayerInputManager.ControlStates.PlanetLaunch);
        }
    }
}