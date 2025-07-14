using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManagerBlockver2 : MonoBehaviour
{
    public static ScoreManagerBlockver2 Instance { get; private set; }

    private int _score = 0;
    [SerializeField] private TMP_Text scoreText;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddScore(int points)
    {
        _score += points;
        scoreText.text = "Score: " + _score;
    }

    public int GetScore()
    {
        return _score;
    }
}
