using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IPL.EventTypes;

public class ScoreManager : SingletonMB<ScoreManager>
{
    [Header("Score")]
    public IntEvent onScoreChange;
    public StringEvent onScoreChangeTxt;
    [Header("Hi Score")]
    public IntEvent onHiScoreChange;
    public StringEvent onHiScoreChangeTxt;

    int score;
    int hiScore;

    public int HiScore
    {
        get => hiScore;
        set
        {
            hiScore = value;
            PlayerPrefs.SetInt("HiScore", hiScore);
            if (onHiScoreChange != null)
                onHiScoreChange.Invoke(hiScore);
            if (onHiScoreChangeTxt != null)
                onHiScoreChangeTxt.Invoke(hiScore.ToString());
        }
    }

    public int Score { get => score;
        set
        {
            score = value;
            if (onScoreChange != null)
                onScoreChange.Invoke(score);
            if (onScoreChangeTxt != null)
                onScoreChangeTxt.Invoke(score.ToString());
        }
    }

    private void OnEnable()
    {
        if (PlayerPrefs.HasKey("HiScore"))
            HiScore = PlayerPrefs.GetInt("HiScore");
    }

    public void IncreaseScore(int amount)
    {
        Score += amount;
        if (Score > HiScore)
            HiScore = Score;
    }
}
