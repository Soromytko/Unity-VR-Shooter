using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLauncher : MonoBehaviour
{
    // private void Start()
    // {
    //     InvokeRepeating("StartGame", 1, 3);
    // }

    [SerializeField] private GameObject _gameOverTextObj;

    public void StartGame()
    {
        foreach (var target in FindObjectsOfType<MovingTarget>())
        {
            target.IsActive = true;
        }

        foreach (var revolver in FindObjectsOfType<Revolver>())
        {
            revolver.IsActive = true;
        }
    }

    public void GameOver()
    {
        foreach (var target in FindObjectsOfType<MovingTarget>())
        {
            target.IsActive = false;
        }

        foreach (var revolver in FindObjectsOfType<Revolver>())
        {
            revolver.IsActive = false;
        }

        _gameOverTextObj.SetActive(true);
    }
}
