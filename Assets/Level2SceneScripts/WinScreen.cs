using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    // Start is called before the first frame update
    //public void PlayGame()
    //{
    //    SceneManager.LoadScene("GameChaptersScene");
    //}

    // To go the the GameChaptersScene.
    public void ExitGame()
    {
        
        // Loading the Scene.
        SceneManager.LoadScene("GameChaptersScene");

    }
}
