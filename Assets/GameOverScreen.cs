using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene("GameChaptersScene");
    }

    public void ExitGame()
    {
        Debug.Log("MainMenuScene");
        Application.Quit();
    }
}
