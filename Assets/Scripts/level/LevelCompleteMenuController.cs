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
        next.onClick.AddListener(LoadNextScene);
    }
    void LoadNextScene()
    {
        int index = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(index);
    }
}
