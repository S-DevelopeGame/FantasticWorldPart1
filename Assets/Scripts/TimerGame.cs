using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerGame : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float timeLeft;
    [SerializeField] private string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        timerText.text = "Time: " + (timeLeft);
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        timerText.text = "Time: " + (timeLeft);
        if (timeLeft < 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}