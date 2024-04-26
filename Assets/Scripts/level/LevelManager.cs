using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }
    [SerializeField]
    private string firstLevel;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    private void Start()
    {
        if (GetLevelStatus(firstLevel) == LevelStatus.Locked)
        {
            SetLevelStatus(firstLevel,LevelStatus.Unlocked);
        }
    }
    public LevelStatus GetLevelStatus(string LevelName)
    {
         return (LevelStatus)PlayerPrefs.GetInt(LevelName,0);   
    }

    public void SetLevelStatus(string LevelName, LevelStatus status)
    {
        PlayerPrefs.SetInt(LevelName, (int)status);
    }

    #region LevelUpdate

    public void UpdateLevels(int levelIndex)
    {
        LevelComplete(levelIndex++);
        LevelUnlocked(levelIndex);
    }

    void LevelUnlocked(int levelIndex)
    {
        SetLevelStatus("level"+levelIndex, LevelStatus.Unlocked);
    }
    void LevelComplete(int levelIndex)
    {
        SetLevelStatus("level"+levelIndex,LevelStatus.Complete);
    }
    #endregion


}
