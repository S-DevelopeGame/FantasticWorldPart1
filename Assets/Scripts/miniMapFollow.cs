using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniMapFollow : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private Vector3 offSet;
    [SerializeField] private GameObject Wall;
    // Start is called before the first frame update
    void Start()
    {
        offSet = transform.position - Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.transform.position + offSet;
    }
}
