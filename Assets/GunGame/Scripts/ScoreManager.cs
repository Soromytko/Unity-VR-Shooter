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
            if (_score > Best)
            {
                Best = value;
            }
        }
    }
    public int Best {get; set; }

    private int _score = 0;

    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _bestText;

    public void Update()
    {
        _scoreText.text = Score.ToString();
        _bestText.text = Best.ToString();
    }


}
