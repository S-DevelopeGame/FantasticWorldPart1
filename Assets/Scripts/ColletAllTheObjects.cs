using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColletAllTheObjects : MonoBehaviour
{
    [SerializeField] private Transform theAllObjects;
    [SerializeField] private GameController gameController;
    [SerializeField] private Transform handPlayer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (theAllObjects.childCount == 0 && handPlayer.childCount == 0)
            gameController.endLevel();
            
    }
}
