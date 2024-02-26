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
    [SerializeField] private Text _gameDurationSliderValueText;
    [SerializeField] private Text _speedSliderValueText;

    private void Start()
    {
        _bestScoreText.text = Settings.BestScore.ToString();
        _gameDurationSlider.value = Settings.GameDuration;
        _speedSlider.value = Settings.GameSpeed;
        //Settings.BestScore = 0;
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
        _gameDurationSliderValueText.text = _gameDurationSlider.value.ToString();
    }

    public void OnSpeedChanged()
    {
        SetSpeed(_speedSlider.value);
        _speedSliderValueText.text = _speedSlider.value.ToString();
    }
}
