using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager Instance;
    [HideInInspector] public string scoreKey = "score";
    [HideInInspector] public string highScoreKey = "highScore";
    
    private int _score;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void IncrementScore()
    {
        _score += 1;
    }

    public void StartScore()
    {
        InvokeRepeating(nameof(IncrementScore), 0.1f, 0.5f);
    }

    public void StopScore()
    {
        CancelInvoke(nameof(IncrementScore));
        
        PlayerPrefs.SetInt(scoreKey, _score);

        if (PlayerPrefs.HasKey(highScoreKey))
        {
            if (_score > PlayerPrefs.GetInt(highScoreKey))
            {
                PlayerPrefs.SetInt(highScoreKey, _score);
            }
        }
        else
        {
            PlayerPrefs.SetInt(highScoreKey, _score);
        }
        
        PlayerPrefs.Save();
    }
    
    
}
