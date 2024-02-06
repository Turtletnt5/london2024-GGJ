using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLose : MonoBehaviour
{
    // Start is called before the first frame update
    public bool LoseCondition = false;

    Collider2D Obstacles_;

    // To make a ref from other script.
    TwoDCharacter_Movement TwoDCharacter;

    // Displaying Gameobjects.
    [SerializeField] Collider2D obstacles_;
    [SerializeField] private Text MylivesText;
    private int lives;

   // private int Lives => lives;
    private int CurrentLives = 3;

    //public Transform spawnPoint;
    public Vector3 spawnPoint;

    private float farthestRow;

    public GameObject RespawnPoint;
    public GameObject Player;


    void Start()
    {

       lives = 3;
       MylivesText.text = "Lives: " + lives; // Display Player's lives from UI.
       //OnTriggerEnter2D(obstacles_);
        //Respawn();
        

    }
    private void NewGame()
    {

        SetLives(3); // To set up Player Lives.
        //NewLevel();
    }

    private void Respawn()
    {
        Losing();
        //TwoDCharacter.Respawn();
        //transform.position = spawnPoint.position;
        //transform.SetPositionAndRotation(spawnPoint, Quaternion.identity);
        //farthestRow = spawnPoint.y;
    }

    private void Losing()
    {
        OnTriggerEnter2D(obstacles_);
    }

    //public void OnTriggerEnter2D(Collider2D Obstacles)
    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (Obstacles.tag == "Obstacles")
        //{
        //    //MylivesText.text = "Lives : " - CurrentLives;
        //    Died();
        //};

        if (other.gameObject.CompareTag("Player") || other.tag == "Obstacles")
        {
            Player.transform.position = RespawnPoint.transform.position;
            Died();
        }
            //SceneManager.LoadScene("GameOverScene");
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
        MylivesText.text = "Lives: " + lives;
    }

    public void Died()
    {
        // Minus lives after player got hit by a obstacles.
        SetLives(lives - 1);

        if (lives > 0)
        {
            // Player is respawning to the starting point after losing live.
            Invoke(nameof(Respawn), 1f);
        }
        else
        {
            // Takes player to the game over screen after losing 3 lives.
            Invoke(nameof(GameOver), 0f);
        }
    }

    private void GameOver()
    {
        //TwoDCharacter.gameObject.SetActive(false);
        //PlayerLose_.OnTriggerEnter2D(obstacles_);
        SceneManager.LoadScene("GameOverScene");
    }


}
