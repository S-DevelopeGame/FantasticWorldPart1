using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HelpMessage : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private TextMeshProUGUI titleMessage;
    [SerializeField] private TextMeshProUGUI message;

    [SerializeField] private string[] messages;
    [SerializeField] private string[] titles;
    private int count;

    private void Start()
    {
        count = 0;
        titleMessage.text = titles[count];
        message.text = messages[count++];
    }

    public void showMessage()
    {
        count = 0;
        titleMessage.text = titles[count];
        message.text = messages[count++];
        image.gameObject.SetActive(true);
    }

    public void nextMessage()
    {
        if(messages.Length <= count)
        {
            image.gameObject.SetActive(false);
            count = 0;
        }
        else
        {
            titleMessage.text = titles[count];
            message.text = messages[count++];
        }
            
       
    }

    public void exitMessage()
    {
        image.gameObject.SetActive(false);
        count = 0;
    }



    
}
