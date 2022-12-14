using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomSceneManager : MonoBehaviour
{
    public static CustomSceneManager Instance { get; private set; }
    
    [SerializeField] private int initSceneIndex = 0;
    [SerializeField] private int titleSceneIndex = 1;
    [SerializeField] private int introSceneIndex = 2;
    [SerializeField] private int mainSceneIndex = 3;
    [SerializeField] private int endSceneIndex = 4;

    public bool IsGameplayScene => SceneManager.GetActiveScene().buildIndex == mainSceneIndex;
    
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
        if (SceneManager.GetActiveScene().buildIndex == initSceneIndex)
        {
            SceneManager.LoadScene(titleSceneIndex);
        }
    }

    private void Update()
    {
        if (!PlayerInputManager.Instance.LeftDown && !PlayerInputManager.Instance.RightDown)
            return;

        if (SceneManager.GetActiveScene().buildIndex == titleSceneIndex)
        {
            SceneManager.LoadScene(introSceneIndex);
        }
        if (SceneManager.GetActiveScene().buildIndex == introSceneIndex)
        {
            SceneManager.LoadScene(mainSceneIndex);
        }
        if (SceneManager.GetActiveScene().buildIndex == endSceneIndex)
        {
            if (EndSceneAnimationProgressTracker.Instance.IsDone)
            {
                Destroy(ScoreManager.Instance.gameObject);
                SceneManager.LoadScene(mainSceneIndex);
            }
        }
    }
    
    public void LoadEndScene()
    {
        SceneManager.LoadScene(endSceneIndex);
    }
}
