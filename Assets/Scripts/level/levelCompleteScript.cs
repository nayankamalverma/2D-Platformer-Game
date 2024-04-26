using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelCompleteScript : MonoBehaviour
{
    [SerializeField]
    private GameObject levelComplete;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<Player_Controller>() != null )
        {
            SoundManger.Instance.Play(Sounds.LevelComplete);
            levelComplete.SetActive(true);
            collision.gameObject.GetComponent<Player_Controller>().enabled = false;
            int index= SceneManager.GetActiveScene().buildIndex;
            LevelManager.Instance.UpdateLevels(index++);
        }
    }
}
