using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private string worldScene;

    public void endLevel()
    {
        SceneManager.LoadScene(worldScene);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void nextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (SceneManager.sceneCountInBuildSettings > nextSceneIndex)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }

    public void aboutScene()
    {
        SceneManager.LoadScene("GameTutorial");
    }

    public void backScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
        
        
            SceneManager.LoadScene(nextSceneIndex);
        
    }

}
