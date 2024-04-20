using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player_Controller>() != null)
        {
            collision.gameObject.GetComponent<Animator>().SetTrigger("death");
            Debug.Log("animation deth");
            collision.gameObject.GetComponent<Player_Controller>().enabled = false;
            collision.gameObject.GetComponent<PlayerHealth>().GameOverMenu();
        }
    }

}
