using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startLocation : MonoBehaviour
{
    [SerializeField] private Transform moveStartLocation;
    void Start()
    {
        transform.position = moveStartLocation.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
