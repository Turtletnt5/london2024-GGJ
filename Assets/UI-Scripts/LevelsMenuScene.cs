using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsMenuScene : MonoBehaviour
{

    public void PlayLevelOne()
    {
        SceneManager.LoadScene("Level1WakingUp");
    }

    public void PlayLevelTwo()
    {
        //SceneManager.LoadScene("Level 2");
    }

    public void BackToTheMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
