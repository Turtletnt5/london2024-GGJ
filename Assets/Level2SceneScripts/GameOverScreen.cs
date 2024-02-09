using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    // Start is called before the first frame update

    // To play the Level 2.
    public void PlayGame()
    {

        // Loading the Scene.
        SceneManager.LoadScene("Level2Scene");

    }

    // Goes to the Main Menu Scene.
    public void ExitGame()
    {

        // Loading the Scene.
        SceneManager.LoadScene("MainMenuScene");

    }
}
