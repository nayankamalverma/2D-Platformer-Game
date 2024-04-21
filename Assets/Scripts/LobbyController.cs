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
    private Button levelButton;
    [SerializeField]
    private GameObject levelSelector;
    [SerializeField] 
    private Button cancelLevelSelector;
    [SerializeField]
    private Button exitButton;


    private void Awake()
    {
        startButton.onClick.AddListener(StartGame);
        levelButton.onClick.AddListener(ActivateLevelSelector);
        cancelLevelSelector.onClick.AddListener(DectivateLevelSelector);
        exitButton.onClick.AddListener(ExitGame);
        
    }
    void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    void ActivateLevelSelector()
    {
        levelSelector.SetActive(true);
    }
    void DectivateLevelSelector()
    {
        levelSelector.SetActive(false);
    }
    void ExitGame()
    {
        Debug.Log("Game closed");
        Application.Quit();
    }
}
