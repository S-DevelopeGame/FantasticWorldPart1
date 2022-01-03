using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsGame : MonoBehaviour
{
    [SerializeField] private float sensativity = 1;
    [SerializeField] private Slider sliderSensitivity;
    [SerializeField] private float maxSensativity;


    [SerializeField] private float volume = 1;
    [SerializeField] private Slider sliderVolume;
    [SerializeField] private float maxVolume;

    [SerializeField] private GameObject menuGamePlay;

    public static bool menuIsActive;

    private AudioSource audio;
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }


    private void Start()
    {
        
        audio = GetComponent<AudioSource>();
        sliderVolume.value = maxVolume;
        sliderSensitivity.value = sensativity;
        setSensativity();
        setVolume();
        if (GameObject.Find("OptionsGamePlay") && GameObject.Find("OptionsGameObject"))
        {
            sliderSensitivity.value = GameObject.Find("OptionsGameObject").GetComponent<OptionsGame>().getSensativity();
            sliderVolume.value = GameObject.Find("OptionsGameObject").GetComponent<OptionsGame>().getVolume();

            Destroy(GameObject.Find("OptionsGameObject"));
        }
    }

    private void setSensativity()
    {
        
            sensativity = sliderSensitivity.value* maxSensativity;
    }

    private void setVolume()
    {
        //if(sliderSensitivity != null)
        volume = sliderVolume.value * maxVolume;
        audio.volume = volume;
    }

    private void Update()
    {
        if(sliderSensitivity!=null)
            setSensativity();
        if (sliderVolume != null)
            setVolume();
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            menuGamePlay.SetActive(true);
            menuIsActive = true;
        }
    }

    public float getSensativity()
    {
        return sensativity;
    }

    public float getVolume()
    {
        return volume;
    }


}
