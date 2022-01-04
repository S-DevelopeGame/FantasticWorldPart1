using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniMapFollow : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private Vector3 offSet;
    [SerializeField] private float leftLimit;
    [SerializeField] private float rightLimit;
    [SerializeField] private float forwardLimit;
    [SerializeField] private float backLimit;

    [SerializeField] private float xLimitMin;
    [SerializeField] private float yLimit;
    [SerializeField] private float zLimitMin;
    [SerializeField] private float zLimitMax;
    [SerializeField] private float xLimitMax;

    [SerializeField] private GameObject block1;
    [SerializeField] private GameObject block2;
    [SerializeField] private GameObject block3;
    [SerializeField] private GameObject block4;
    private bool flag;
    // Start is called before the first frame update
    void Start()
    {

        offSet = transform.position - Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position.z > block1.transform.position.z + 38

                transform.position = Player.transform.position + offSet;

            

        
        
    }
}
