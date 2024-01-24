using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
}
