using System;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    public static PlayerInputManager Instance { get; private set; }
    
    public enum ControlStates
    {
        PlanetLaunch,
        RocketSteering
    }

    public ControlStates ControlState { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ControlState = ControlStates.PlanetLaunch;
    }
    
    public void SetControlState(ControlStates controlState)
    {
        ControlState = controlState;
    }
}