using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    private Button btn;
    [SerializeField]
    private GameObject lockImage;
    [SerializeField]
    private string levelName;
    private LevelStatus levelStatus;
    private void Awake()
    {
        levelStatus = LevelManager.Instance.GetLevelStatus(levelName);
        btn = GetComponent<Button>();
        btn.onClick.AddListener(LoadLevel);
        if (levelStatus == LevelStatus.Locked)
        {
            lockImage.SetActive(true);
        }
        else
        {
            lockImage.SetActive(false);
        }
    }

    private void LoadLevel()
    {
        
        switch (levelStatus)
        {
            case LevelStatus.Locked:
                Debug.Log(levelName + " is Locked ");
                break;
            case LevelStatus.Unlocked:
                SceneManager.LoadScene(levelName);
                break;
            case LevelStatus.Complete:
                SceneManager.LoadScene(levelName);
                break;
        }
    }
}
