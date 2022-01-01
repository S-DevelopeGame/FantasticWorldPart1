using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sensitivity : MonoBehaviour
{
    public static float sensativity = 1;
    [SerializeField] private Slider sliderSensitivity;
    
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }


    private void Start()
    {
        setSensativity();
    }

    private void setSensativity()
    {
        //if(sliderSensitivity != null)
            sensativity = sliderSensitivity.value * 150;
    }

}
