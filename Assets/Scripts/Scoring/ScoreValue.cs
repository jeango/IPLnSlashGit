using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreValue : MonoBehaviour
{
    [SerializeField]
    int score = 0;

    public void GainScore()
    {
        ScoreManager.GetInstance().IncreaseScore(score);
    }
}
