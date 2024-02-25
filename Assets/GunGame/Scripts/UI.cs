using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _bestScoreText;
    [SerializeField] private Timer _gameDurationTimer;

    public void Start()
    {
        _scoreText.text = 0.ToString();
        _bestScoreText.text = Settings.BestScore.ToString();

        float speed = Settings.GameSpeed;
        foreach (var target in FindObjectsOfType<MovingTarget>())
        {
            target.Speed = speed;
        }

        _gameDurationTimer.Value = Settings.GameDuration;
    }

    public void OnRestartButtonPressed()
    {
        SceneManager.LoadScene("Gun");
    }

    public void OnExitButtonPressed()
    {
        SceneManager.LoadScene("Lobby");
    }

}
