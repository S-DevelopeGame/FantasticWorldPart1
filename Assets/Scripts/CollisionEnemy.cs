using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEnemy : MonoBehaviour
{
    [SerializeField] private Transform jail;
    // Start is called before the first frame update
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.transform.parent = jail;
            collision.transform.position = jail.position;
            collision.gameObject.GetComponent<Chaser>().enabled = false;
            collision.gameObject.GetComponent<EnemyController3>().enabled = false;
            collision.gameObject.GetComponent<Patroller>().enabled = false;
        }


    }
}
