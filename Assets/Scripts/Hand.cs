using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    Vector3 playerPos;
    Vector3 ThisPos;
    public GameObject Player;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (Player != null)
        {
            playerPos = Player.transform.position;
        }

        ThisPos = transform.position;

        Collider2D[] collis = Physics2D.OverlapCircleAll(transform.position, 10); // this creates a range so that when the player enters it the ai will tell it to move away
        foreach (Collider2D colli in collis)
        {
            if (colli && colli.tag == "Player")
            { // if object has the right tag...
                transform.position = Vector2.Lerp(ThisPos, -playerPos, Time.deltaTime * 20); // this tells it to move toward the inverse of the players position.
            }
        }
    }
}
