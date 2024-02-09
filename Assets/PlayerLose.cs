using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLose : MonoBehaviour
{
    //// Start is called before the first frame update
    //public bool LoseCondition = false;

    //Collider2D Obstacles_;

    //// To make a ref from other script.
    //TwoDCharacter_Movement TwoDCharacter;

    //// Displaying Gameobjects.
    //[SerializeField] Collider2D obstacles_;
    //[SerializeField] private Text MylivesText;
    //private int lives;

    ////public Transform spawnPoint;
    //public Vector3 spawnPoint;

    //private float farthestRow;

    //public GameObject RespawnPoint;
    //public GameObject Player;

    private Vector3 spawnPosition;
    Vector2 CheckpointPos;

    // Update is called once per frame

    private SpriteRenderer spriteRenderer;
    private int lives;

    //PlayerLose player__;

    private float farthestRow;
    private bool cooldown;

    [SerializeField] TwoDCharacter_Movement Player_;

    ///////////////////////////////////////////////////////////

    [SerializeField] private Text MylivesText;

    void Start()
    {
        CheckpointPos = transform.position;
        NewGame();
    }

    private void Awake()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        spawnPosition = transform.position;

    }



    private void NewGame()
    {
        SetLives(3);
        NewLevel();
    }

    private void NewLevel()
    {
        Respawn();
    }

    private void Respawn()
    {
        //playerRB.simulated = false;
        transform.SetPositionAndRotation(spawnPosition, Quaternion.identity);
        farthestRow = spawnPosition.y;

        transform.position = CheckpointPos;

        gameObject.SetActive(true);
        enabled = true;
        cooldown = false;
    }

    public void UpdateCheckpoint(Vector2 pos)
    {
        CheckpointPos = pos;
    }

    //public void Losing()
    //{
    //    OnTriggerEnter2D(obstacles_);
    //}

    //blic void OnTriggerEnter2D(Collider2D Obstacles)
    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (Obstacles.tag == "Obstacles")
        //{
        //    //MylivesText.text = "Lives : " - CurrentLives;
        //    Died();
        //};

        bool hitObstacle = other.gameObject.layer == LayerMask.NameToLayer("Obstacles");

        if (enabled && hitObstacle)
        {
            Died();
        }
        //SceneManager.LoadScene("GameOverScene");
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
        MylivesText.text = lives.ToString();
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
