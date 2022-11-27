using System;
using UnityEngine;

namespace Ship
{
    public class PlayerShipController : MonoBehaviour
    {
        [SerializeField] private float turnSpeed;

        private void Update() 
        {
            DoRotation();
        }

        private void DoRotation() 
        {
            if (PlayerInputManager.Instance.ControlState == PlayerInputManager.ControlStates.RocketSteering)
            {
                if (PlayerInputManager.Instance.Left)
                {
                    transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
                }
                if (PlayerInputManager.Instance.Right)
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