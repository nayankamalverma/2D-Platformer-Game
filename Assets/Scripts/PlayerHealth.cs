using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float InitialHealth;
    public float CurrentHealth {  get; private set; }
    private Animator anim;
    private bool isAlive;
    private void Awake()
    {
        CurrentHealth = InitialHealth;
        anim = GetComponent<Animator>();
        isAlive = true;
    }

    public void TakeDamage(float dmg)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth - dmg, 0, InitialHealth);
        if(CurrentHealth > 0) {
            anim.SetTrigger("hurt");
        }
        else
        {
            if(isAlive)
            {
                anim.SetTrigger("death");
                GetComponent<Player_Controller>().enabled = false;
                isAlive = false;

                StartCoroutine(MyCoroutine());
            }
        }
    }
    IEnumerator MyCoroutine()
    {
        Debug.Log("Coroutine started at " + Time.time);

        // Pause the execution of this coroutine for 2 seconds
        yield return new WaitForSeconds(3);

        Debug.Log("Coroutine resumed at " + Time.time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
