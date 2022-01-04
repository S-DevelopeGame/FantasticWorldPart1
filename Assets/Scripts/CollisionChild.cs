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
    [SerializeField] private GameObject child1;
    [SerializeField] private GameObject child2;
    [SerializeField] private float distanceFromChild;
    [SerializeField] private GameObject starChild;
    [SerializeField] private GameObject starChild1;
    [SerializeField] private GameObject starChild2;
    [SerializeField] private GameObject arrowTutorial;
    [SerializeField] private TextMeshProUGUI textChildT;
    float distance1;
    float distance2;
    private void Update()
    {
        
        float distance = Vector3.Distance(child.transform.position, this.transform.position);
        
        if (child1 != null)
            distance1 = Vector3.Distance(child1.transform.position, this.transform.position);
        if(child2 != null)
            distance2 = Vector3.Distance(child2.transform.position, this.transform.position);
         
        if (!dialogImage1.gameObject.activeSelf && !dialogImage2.gameObject.activeSelf && (distance < distanceFromChild || (distance1 != 0 && distance1 < distanceFromChild) || (distance2 != 0 && distance2 < distanceFromChild)))
        {
            textChildT.gameObject.SetActive(true);
        }
        else
        {
            textChildT.gameObject.SetActive(false);
        }
        if (distance < distanceFromChild && Input.GetKeyDown(KeyCode.T))
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
        else if(child1 != null && distance1 < distanceFromChild && Input.GetKeyDown(KeyCode.T))
        {
            if (arrowTutorial != null && arrowTutorial.activeSelf)
                arrowTutorial.SetActive(false);


            if (!starChild1.activeSelf && !dialogImage1.gameObject.activeSelf)
            {
                dialogImage1.gameObject.SetActive(true);
                starChild1.SetActive(true);
            }
            else if (!dialogImage1.gameObject.activeSelf)
                dialogImage2.gameObject.SetActive(true);
            child1.GetComponent<ChildThrowObjects>().enabled = false;
        }
        else if (child2 != null && distance2 < distanceFromChild && Input.GetKeyDown(KeyCode.T))
        {
            if (arrowTutorial != null && arrowTutorial.activeSelf)
                arrowTutorial.SetActive(false);


            if (!starChild2.activeSelf && !dialogImage1.gameObject.activeSelf)
            {
                dialogImage1.gameObject.SetActive(true);
                starChild2.SetActive(true);
            }
            else if (!dialogImage1.gameObject.activeSelf)
                dialogImage2.gameObject.SetActive(true);
            child2.GetComponent<ChildThrowObjects>().enabled = false;
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
