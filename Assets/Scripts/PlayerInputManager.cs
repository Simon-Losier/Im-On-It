using System;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    public static PlayerInputManager Instance { get; private set; }
    
    public bool Left { get; private set; }
    public bool Right { get; private set; }
    public bool LeftDown { get; private set; }
    public bool RightDown { get; private set; }
    
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

    private void Update()
    {
        Left = Input.GetKey(KeyCode.A);
        Right = Input.GetKey(KeyCode.D);
        LeftDown = Input.GetKeyDown(KeyCode.A);
        RightDown = Input.GetKeyDown(KeyCode.D);
    }
}