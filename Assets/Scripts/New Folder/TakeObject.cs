using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TakeObject : MonoBehaviour
{
    [SerializeField] private Transform hand;
    [SerializeField] private RecycleBin[] recycleBins;
    [SerializeField] private Transform allObjects;
    [SerializeField] private TextMeshProUGUI textPoints;
    private Vector3 lastPosition;
    private int score = 0; // score of the player
    //[SerializeField] private string type;
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "pickup" && hand.childCount == 0)
        {
            
            Debug.Log("Collision");
            lastPosition = collision.transform.position;
            collision.transform.parent = hand;
            collision.transform.position = hand.position;
            Debug.Log("ZZZ");

            for (int i = 0; i < recycleBins.Length; i++)
            {
                if(collision.gameObject.GetComponent<TypeObject>() != null)
                {
                    if (recycleBins[i].getType().Equals(collision.gameObject.GetComponent<TypeObject>().getType()))
                    {
                        recycleBins[i].setOpen(true);
                    }
                }
                else
                {
                    Debug.Log("need to put TypeObject");
                }


            }

        }

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "recyclebin" && hand.childCount != 0)
        {
            if (collision.gameObject.GetComponent<RecycleBin>().getOpen())
            {
                Destroy(hand.GetChild(0).gameObject);
                addPoint();
                collision.gameObject.GetComponent<RecycleBin>().setOpen(false);
            }
            else
            {
                GameObject g = hand.GetChild(0).gameObject;
                hand.GetChild(0).transform.parent = null;
                g.transform.position = lastPosition;
                g.transform.parent = allObjects;
                for (int i = 0; i < recycleBins.Length; i++)
                {
                    recycleBins[i].setOpen(false);
                }
            }

                
        }
    }

    private void addPoint()
    {
        //AddPoint
        textPoints.text = "Score: " + (++score); // add point to the GUI
    }


    // Start is called before the first frame update

}
