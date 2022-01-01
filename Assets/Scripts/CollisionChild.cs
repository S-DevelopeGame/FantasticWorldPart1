using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class CollisionChild : MonoBehaviour
{
    [SerializeField] private Image dialogImage1;
    [SerializeField] private Image dialogImage2;
    [SerializeField] private GameObject child;
    [SerializeField] private float distanceFromChild;
    [SerializeField] private GameObject starChild;
    [SerializeField] private GameObject arrowTutorial;
    [SerializeField] private TextMeshProUGUI textChildT;
    private void Update()
    {
        float distance = Vector3.Distance(child.transform.position, this.transform.position);
        if (!dialogImage1.gameObject.activeSelf && !dialogImage2.gameObject.activeSelf && distance < distanceFromChild)
        {
            textChildT.gameObject.SetActive(true);
        }
        else
        {
            textChildT.gameObject.SetActive(false);
        }
        if (distance < distanceFromChild & Input.GetKeyDown(KeyCode.T))
        {
            if (arrowTutorial != null && arrowTutorial.activeSelf)
                arrowTutorial.SetActive(false);

            
            if(!starChild.activeSelf && !dialogImage1.gameObject.activeSelf)
            {
                dialogImage1.gameObject.SetActive(true);
                starChild.SetActive(true);
            } 
            else if(!dialogImage1.gameObject.activeSelf)
                dialogImage2.gameObject.SetActive(true);
            child.GetComponent<ChildThrowObjects>().enabled = false;
        }

    }
    /*
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Child")
        {
            dialogImage.gameObject.SetActive(true);
            collision.gameObject.GetComponent<NavMeshAgent>().speed = 0;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Child")
        {
            collision.gameObject.GetComponent<NavMeshAgent>().speed = 0;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Child")
        {
            dialogImage.gameObject.SetActive(false);

            collision.gameObject.GetComponent<NavMeshAgent>().speed = 3;

        }
    }

    */
}
