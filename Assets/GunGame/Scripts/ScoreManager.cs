using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int Score
    {
        get => _score;
        set
        {
            _score = value;
            _scoreText.text = _score.ToString();
        }
    }
    public int Best
    {
        get => _best;
        set {
            _best = value;
            _bestText.text = _best.ToString();
        }
    }

    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _bestText;
    private int _score = 0;
    private int _best = 0;

    private void Start()
    {
        Best = Settings.BestScore;
    }

    public void Update()
    {
        _scoreText.text = Score.ToString();
    }

    public void OnGameOver()
    {
        if (Score > Best) {
            Settings.BestScore = Score;
            Best = Score;
        }
    }


}
