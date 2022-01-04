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
    // Start is called before the first frame update
    void Start()
    {

        offSet = transform.position - Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.transform.position.x > xLimitMin || Player.transform.position.z > zLimitMin || Player.transform.position.z < zLimitMax)
            transform.position = Player.transform.position + offSet;
    }
}
