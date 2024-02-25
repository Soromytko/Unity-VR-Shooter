using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    [SerializeField] private Text _bestScoreText;
    [SerializeField] private Slider _gameDurationSlider;
    [SerializeField] private Slider _speedSlider;

    private void Start()
    {
        _bestScoreText.text = Settings.BestScore.ToString();
        _gameDurationSlider.value = Settings.GameDuration;
        _speedSlider.value = Settings.GameSpeed;
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene("Gun");
    }

    public void SetGameDuration(float sec)
    {
        Settings.GameDuration = sec;
    }

    public void SetSpeed(float value)
    {
        Settings.GameSpeed = value;
    }

    public void OnGameDurationChanged()
    {
        SetGameDuration(_gameDurationSlider.value);
    }

    public void OnSpeedChanged()
    {
        SetSpeed(_speedSlider.value);
    }
}
