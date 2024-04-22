using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    private Button btn;
    [SerializeField]
    private string levelName;

    private void Awake()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(LoadLevel);
    }

    private void LoadLevel()
    {
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(levelName);
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
