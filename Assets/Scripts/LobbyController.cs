using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    [SerializeField]
    private Button startButton;
    [SerializeField]
    private Button exitButton;
    private void Awake()
    {
        startButton.onClick.AddListener(StartGame);
        exitButton.onClick.AddListener(ExitGame);
    }
    void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    void ExitGame()
    {
        Debug.Log("Game closed");
        Application.Quit();
    }
}
