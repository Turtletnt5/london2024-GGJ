using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScene : MonoBehaviour
{
    public void PlayGame()
    {
        //SceneManager.LoadScene("GameChaptersScene");
    }

    public void CreditScreen()
    {
        SceneManager.LoadScene("CreditsMenuScene");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

}
