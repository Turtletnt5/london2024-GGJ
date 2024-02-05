using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLose : MonoBehaviour
{
    // Start is called before the first frame update
    public bool LoseCondition = false;

    private void OnTriggerEnter2D(Collider2D Obstacles)
    {
        if (Obstacles.tag == "Obstacles")
            SceneManager.LoadScene("GameOverScene");
    }
}
