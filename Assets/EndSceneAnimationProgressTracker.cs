using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneAnimationProgressTracker : MonoBehaviour
{
    public static EndSceneAnimationProgressTracker Instance { get; private set; }
    

    [SerializeField] private bool isDone;
    public bool IsDone => isDone;

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
}
