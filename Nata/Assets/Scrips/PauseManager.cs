using System;
using UnityEngine;
using UnityEditor;

public class PauseManager: MonoBehaviour
{
public GameObject _pauseMenu;
private bool _isGamePaused = false;   
    public void TogglePause()
    {
        if (!_isGamePaused)
        {
            _isGamePaused = true;
            _pauseMenu.SetActive(true);
            Time.timeScale = 0.0f;
        }
        else
        {
            _isGamePaused = false;
            _pauseMenu.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }
}