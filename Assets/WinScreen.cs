using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene("GameChaptersScene");
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
