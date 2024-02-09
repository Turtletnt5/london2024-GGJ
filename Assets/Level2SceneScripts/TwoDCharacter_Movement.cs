using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TwoDCharacter_Movement : MonoBehaviour
{

    // Update is called once per frame


    // Variables for functions below.

    // For Starting point.
    private Vector3 spawnPosition;

    // For Checkpoint.
    Vector2 CheckpointPos;

    // To Renderer Player Sprite.
    private SpriteRenderer spriteRenderer;

    // Player Lives.
    private int lives;

    // Part of SpawnPosition above.
    private float farthestRow; 

    // Display lives numbers.
    [SerializeField] private Text MylivesText; 

    void Start()
    {

        // To activite the Checkpoint.
        CheckpointPos = transform.position;

        // To Start Game.
        NewGame(); 
    }

    private void Awake()
    {
        // To get the player sprite renderer.
        spriteRenderer = GetComponent<SpriteRenderer>();

    }


    // When the game started.
    private void NewGame()
    {
        // Setting up live numbers.
        SetLives(3);

        // To start from the starting point.
        NewLevel();
    }

    // When the player spawns from Starting point or Checkpoint.
    private void NewLevel()
    {
        // When the Player Respawns.
        Respawn();
    }

    // Controll player with keyboard.
    private void Update()
    {
        // Up.
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            //transform.rotation = Quaternion.Euler(0f, 0f, 0f);

            // Moving Up.
            Move(Vector3.up); 
        }

        // Down.
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            //transform.rotation = Quaternion.Euler(0f, 0f, 180f);

            //Moving Down.
            Move(Vector3.down); 
        }

        // Left.
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //transform.rotation = Quaternion.Euler(0f, 0f, 90f);

            // Moving Left.
            Move(Vector3.left);
        }

        // Right.
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {

            //transform.rotation = Quaternion.Euler(0f, 0f, -90f);

            // Moving Right.
            Move(Vector3.right);
        }
    }

    // Player Movement.
    public void Move(Vector3 Direction)
    {

        // Moving Player.
        Vector3 Destination = transform.position + Direction;

        // Tagging Barrier for the GameObjects GameObjects that's tagged.
        Collider2D barrier = Physics2D.OverlapBox(Destination, Vector2.zero, 0f, LayerMask.GetMask("Barrier"));

        // Tagging Obstacles for the GameObjects that's tagged.
        Collider2D obstacle = Physics2D.OverlapBox(Destination, Vector2.zero, 0f, LayerMask.GetMask("Obstacles"));

        // To stop player from going out of bounds.
        if (barrier != null)
        {
            return;
        }

        // When the player got hit by an Obstacles.
        if (obstacle != null)
        {

            // Obstacles.
            transform.position = Destination;

            // Player losing lives.
            PlayerDied(); 

        }

        // Goes to Leap.
        StartCoroutine(Leap(Destination));
    }

    // 
    private IEnumerator Leap(Vector3 destination)
    {
        // Player moving
        Vector3 startPosition = transform.position;
        float elapsed = 0f;
        float duration = 0.125f;

        while (elapsed < duration)
        {
            // Move towards the destination over time
            float t = elapsed / duration;
            transform.position = Vector3.Lerp(startPosition, destination, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Set final state
        transform.position = destination;

    }

    // When the player touches the Checkpoint.
    public void UpdateCheckpoint(Vector2 pos)
    {

        // Position of the Checkpoint spawn.
        CheckpointPos = pos;
    }

    // When the player respawns either in Starting Point or Checkpoint.
    public void Respawn()
    {

        // From Starting Point.
        transform.SetPositionAndRotation(spawnPosition, Quaternion.identity);
        farthestRow = spawnPosition.y;

        // From Checkpoint
        transform.position = CheckpointPos;

        // To have the gameobject active.
        gameObject.SetActive(true);

        // Enable control.
        enabled = true;

    }

    // When the player respawn after losing live.
    public void PlayerDied()
    {
        // Disable control.
        enabled = false;

        // Minus Lives.
        SetLives(lives - 1);

        // If the live reaches 0, then it's Game Over.
        if (lives > 0)
        {
            // Respawns to either the starting point or checkpoint.
            Invoke(nameof(Respawn), 1f);
        }
        else
        {
            // Goes to the GameOver after losing all lives.
            Invoke(nameof(GameOver), 0f);
        }

    }
    // Set lives number.
    private void SetLives(int lives)
    {

        // Referencing to the Player's lives.
        this.lives = lives;

        // When the numbers are displayed.
        MylivesText.text = lives.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // When the player got hit by a obstacles.
        bool hitObstacle = other.gameObject.layer == LayerMask.NameToLayer("Obstacles");

        if (enabled && hitObstacle)
        {
            PlayerDied();
        }
    }

    // Goes to the Game Over Screen.
    private void GameOver()
    {
        SceneManager.LoadScene("GameOverScene");

    }


}

