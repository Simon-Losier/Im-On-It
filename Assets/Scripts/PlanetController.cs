using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    [SerializeField] private float kickForce = 10f;
    
    private SpawnObjectAtPoint _spawnObjectAtPoint;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _spawnObjectAtPoint = GetComponent<SpawnObjectAtPoint>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (PlayerInputManager.Instance.ControlState == PlayerInputManager.ControlStates.PlanetLaunch)
        {
            if (PlayerInputManager.Instance.LeftDown || PlayerInputManager.Instance.RightDown)
            {
                _rigidbody.AddForce(-transform.forward * kickForce, ForceMode.Impulse);
                _spawnObjectAtPoint.SpawnObject();
                PlayerInputManager.Instance.SetControlState(PlayerInputManager.ControlStates.RocketSteering); // this line is so long lol
            }
        }
    }

    private void OnDestroy()
    {
        CustomSceneManager.Instance.LoadEndScene();
    }
}
