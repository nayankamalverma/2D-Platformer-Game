using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelCompleteScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player_Controller>() != null )
        {
            int index= SceneManager.GetActiveScene().buildIndex;
            LevelManager.Instance.UpdateLevels(index++);
 //           Debug.Log("level" + index + " " + LevelManager.Instance.GetLevelStatus("level" + index++));
 //           Debug.Log("level" + index + " "+ LevelManager.Instance.GetLevelStatus("level" + index));
            SceneManager.LoadScene(index);
        }
    }
}
