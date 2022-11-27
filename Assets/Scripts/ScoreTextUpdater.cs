using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTextUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText.text = "$0.00";
    }
    
    private void UpdateScoreText(float score)
    {
        scoreText.text = "$" + score.ToString("F2");
    }

    private void Update()
    {
        UpdateScoreText(ScoreManager.Instance.CurrentScore);
    }
}
