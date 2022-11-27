using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomSceneManager : MonoBehaviour
{
    public static CustomSceneManager Instance { get; private set; }
    
    [SerializeField] private int initSceneIndex = 0;
    [SerializeField] private int introSceneIndex = 1;
    [SerializeField] private int mainSceneIndex = 2;
    [SerializeField] private int endSceneIndex = 3;

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
            SceneManager.LoadScene(introSceneIndex);
        }
    }

    private void Update()
    {
        if (!PlayerInputManager.Instance.LeftDown && !PlayerInputManager.Instance.RightDown)
            return;

        if (SceneManager.GetActiveScene().buildIndex == introSceneIndex)
        {
            SceneManager.LoadScene(mainSceneIndex);
        }
        if (SceneManager.GetActiveScene().buildIndex == endSceneIndex)
        {
            Destroy(ScoreManager.Instance.gameObject);
            SceneManager.LoadScene(mainSceneIndex);
        }
    }
    
    public void LoadEndScene()
    {
        SceneManager.LoadScene(endSceneIndex);
    }
}
