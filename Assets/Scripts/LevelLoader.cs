using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    private Button btn;
    [SerializeField]
    private string level;

    private void Awake()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(LoadLevel);
    }

    private void LoadLevel()
    {
        SceneManager.LoadScene(level);
    }
}
