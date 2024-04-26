using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player_Controller>() != null)
        {
            anim.SetTrigger("death");
            collision.gameObject.GetComponent<Player_Controller>().enabled = false;
            collision.gameObject.GetComponent<PlayerHealth>().GameOverMenu();
        }
    }

}
