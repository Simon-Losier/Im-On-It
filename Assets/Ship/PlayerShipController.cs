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

        public ParticleSystem particleSystem;
        public float highSpeed = 20f;
        public float lowSpeed = 10f;
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

                if (PlayerInputManager.Instance.Left && PlayerInputManager.Instance.Right)
                {
                    var emission = particleSystem.emission;
                    emission.rateOverTime = highSpeed;
                }
                else
                {
                    var emission = particleSystem.emission;
                    emission.rateOverTime = lowSpeed;
                }
            }
        }

        private void OnDestroy()
        {
            PlayerInputManager.Instance.SetControlState(PlayerInputManager.ControlStates.PlanetLaunch);
        }
    }
}