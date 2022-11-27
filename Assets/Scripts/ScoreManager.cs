using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    
    [SerializeField] private float wagePerHour = 10f;
    private float _wagePerSecond;
    
    public float CurrentScore { get; private set; }
    public bool active = true;

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
        CurrentScore = 0f;
        DontDestroyOnLoad(gameObject);
        
        _wagePerSecond = wagePerHour / 3600f;
    }
    
    public void AddScore(float score)
    {
        CurrentScore += score;
    }

    private void Update()
    {
        if (active && CustomSceneManager.Instance.IsGameplayScene)
            AddScore(_wagePerSecond * Time.deltaTime);
    }
}
