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
        SoundManger.Instance.Play(Sounds.StartGame);
        SceneManager.LoadScene(1);
    }
    void ActivateLevelSelector()
    {
        SoundManger.Instance.Play(Sounds.ButtonClick);
        levelSelector.SetActive(true);
    }
    void DectivateLevelSelector()
    {
        SoundManger.Instance.Play(Sounds.ButtonClick);
        levelSelector.SetActive(false);
    }
    void ExitGame()
    {
        SoundManger.Instance.Play(Sounds.ButtonClick);
        Debug.Log("Game closed");
        Application.Quit();
    }
}
