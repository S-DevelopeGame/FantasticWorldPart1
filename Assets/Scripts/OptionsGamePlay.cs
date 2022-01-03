using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsGamePlay : MonoBehaviour
{
    static float sensitivity;
    static float volume;
    // Update is called once per frame

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }



}
