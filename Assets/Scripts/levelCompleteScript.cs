using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelCompleteScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player_Controller>() != null)
        {
            if(SceneManager.GetActiveScene().buildIndex == 1) {
                SceneManager.LoadScene(2);
                Debug.Log("level 1 complete");
            }
            else
            {
                SceneManager.LoadScene(0);
                Debug.Log("level 2 complete");
            }
        }
    }
}
