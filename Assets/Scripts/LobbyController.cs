using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    [SerializeField]
    private Button startButton;
    private void Awake()
    {
        startButton.onClick.AddListener(StartGame);
    }
    void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
