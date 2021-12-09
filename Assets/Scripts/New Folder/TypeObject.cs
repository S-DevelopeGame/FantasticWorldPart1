using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeObject : MonoBehaviour
{

    [SerializeField] string type;


    public string getType()
    {
        return type;
    }
}
