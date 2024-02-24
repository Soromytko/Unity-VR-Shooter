using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public void OnRestartButtonPressed()
    {
        FindObjectOfType<ScoreManager>().Score = 0;
        //SceneManager.LoadScene("Gun");
    }

    public void OnExitButtonPressed()
    {
        FindObjectOfType<ScoreManager>().Score = 0;
        //SceneManager.LoadScene("Lobby");
    }

    public void OnSpeedChanged()
    {
        float value = FindObjectOfType<Slider>().value;
        foreach (var target in FindObjectsOfType<MovingTarget>())
        {
            target.Speed = value;
        }
    }

    // Лобби
    // Таймер
    // Таблица рекордов
    // Вынести настройки в лоббив
}
