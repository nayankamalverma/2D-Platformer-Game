using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private GameObject pointA;
    [SerializeField]
    private GameObject pointB;
    private Animation anim;
    private Transform currentPoint;

    private void Awake()
    {
        anim = GetComponent<Animation>();
        currentPoint = pointA.transform;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player_Controller>() != null)
        {
            Player_Controller player = collision.gameObject.GetComponent<Player_Controller>();
            player.GotHurt();
        }
    }

}
