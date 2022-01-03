using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookX : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 1f;
    private float sensitivity;
    private OptionsGame OptionsGamePlay;
    private float lastSensitivity;
    private void Start()
    {
        if (GameObject.Find("OptionsGamePlay") != null)
        {
            OptionsGamePlay = GameObject.Find("OptionsGamePlay").GetComponent<OptionsGame>();
            sensitivity = OptionsGamePlay.getSensativity();
        }
        else if (GameObject.Find("OptionsGameObject") != null)
        {
            OptionsGamePlay = GameObject.Find("OptionsGameObject").GetComponent<OptionsGame>();
            sensitivity = OptionsGamePlay.getSensativity();
        }
            
    }
    void Update()
    {
        if (OptionsGamePlay.getSensativity() != sensitivity)
            sensitivity = OptionsGamePlay.getSensativity();

    
        float mouseX = Input.GetAxis("Mouse X");
        //Debug.Log("mouse x = " + _mouseX);
        Vector3 rotation = transform.localEulerAngles;
        rotation.y += mouseX * sensitivity + rotationSpeed * mouseX;  // Rotation around the vertical (Y) axis
        transform.localEulerAngles = rotation;
    }
}
