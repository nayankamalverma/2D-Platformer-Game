using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private TextMeshProUGUI ScoreText;
    private int score=0;

    private void Awake()
    {
        ScoreText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        
    }
    public void IncreaseScore(int inc)
    {
        score += inc;
        UpdateScoreText();
    }
    private void UpdateScoreText()
    {
        ScoreText.text = "Score : "+ score;
    }
}
