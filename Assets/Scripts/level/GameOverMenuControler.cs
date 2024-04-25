using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenuControler : MonoBehaviour
{
    [SerializeField]
    private Button restartButton;
    [SerializeField]
    private Button mainMenuButton;

    private void Awake()
    {
        restartButton.onClick.AddListener(ReloadLevel);
        mainMenuButton.onClick.AddListener(GoLobby);
    }

    private void ReloadLevel()
    {
        SoundManger.Instance.Play(Sounds.StartGame);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void GoLobby()
    {
        SoundManger.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(0);
    }
}
