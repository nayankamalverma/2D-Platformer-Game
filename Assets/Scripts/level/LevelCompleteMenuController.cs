using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelCompleteMenuController : MonoBehaviour
{
    [SerializeField]
    private Button next;
    private void Awake()
    {
        
        if(next.name == "Menu") next.onClick.AddListener(LoadLobby);
        else next.onClick.AddListener(LoadNextScene);
    }
    void LoadNextScene()
    {
        int index = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(index);
    }
    void LoadLobby()
    {
        SceneManager.LoadScene(0);
    }
}
