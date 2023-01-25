using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    private int score = 0;
    TMP_Text scoreText;

    private void Awake() {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "000000000";
    }
    
    public void IncreaseScore(int amountToIncrease)
    {
        score += amountToIncrease;
        scoreText.text = score.ToString("000000000");
    }
}
