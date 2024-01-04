using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;

    private void Start()
    {
        scoreText.text = "Score : 0";
    }
    public void IncreaseScore(int scoreAdded)
    {
        score += scoreAdded;
        scoreText.text = "Total Killed : " + score.ToString();
    }
}
