using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public void OnRestartButtonPressed()
    {
        SceneManager.LoadScene("Gun");
    }

    public void OnExitButtonPressed()
    {
        SceneManager.LoadScene("Lobby");
    }
}
