using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private string worldScene;
    [SerializeField] private string tutorialScene;
    [SerializeField] private string multiPlayerScene;

    public void moveEndLevel()
    {
        SceneManager.LoadScene(worldScene);
    }

    public void moveExitGame()
    {
        Application.Quit();
    }

    public void moveNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (SceneManager.sceneCountInBuildSettings > nextSceneIndex)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }

    public void moveTutorialScene()
    {
        SceneManager.LoadScene(tutorialScene);
    }

    public void moveMultiPlayerScene()
    {
        SceneManager.LoadScene(multiPlayerScene);
    }

    public void moveBackScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
        
        
            SceneManager.LoadScene(nextSceneIndex);
        
    }

}
