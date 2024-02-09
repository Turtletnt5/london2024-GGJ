using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TwoDCharacter_Movement : MonoBehaviour
{
    private Vector3 spawnPosition;
    Vector2 CheckpointPos;

    // Update is called once per frame

    private SpriteRenderer spriteRenderer;
    private int lives;

    //PlayerLose player__;

    private float farthestRow;
    private bool cooldown;

    //[SerializeField] TwoDCharacter_Movement Player_;

    /////////////////////////////////////////////////////////////

    //[SerializeField] private Text MylivesText;

    void Start()
    {
        //CheckpointPos = transform.position;
        //NewGame();
    }

    private void Awake()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        //spawnPosition = transform.position;

    }



    //private void NewGame()
    //{
    //    SetLives(3);
    //    NewLevel();
    //}

    //private void NewLevel()
    //{
    //    Respawn();
    //}


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            //transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            Move(Vector3.up);
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            //transform.rotation = Quaternion.Euler(0f, 0f, 180f);
            Move(Vector3.down);
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            Move(Vector3.left);
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            //transform.rotation = Quaternion.Euler(0f, 0f, -90f);
            Move(Vector3.right);
        }
    }

    private void Move(Vector3 Direction)
    {
        if (cooldown) return;
        Vector3 Destination = transform.position + Direction;
        Collider2D barrier = Physics2D.OverlapBox(Destination, Vector2.zero, 0f, LayerMask.GetMask("Barrier"));
        Collider2D obstacle = Physics2D.OverlapBox(Destination, Vector2.zero, 0f, LayerMask.GetMask("Obstacles"));
        if (barrier != null)
        {
            return;
        }

        if (obstacle != null)
        {
            transform.position = Destination;
            //PlayerDied();
        }

        StartCoroutine(Leap(Destination));
    }

    private IEnumerator Leap(Vector3 destination)
    {
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

        cooldown = false;
    }

    //public void UpdateCheckpoint(Vector2 pos)
    //{
    //    CheckpointPos = pos;
    //}

    //public void Respawn()
    //{

    //    //playerRB.simulated = false;
    //    transform.SetPositionAndRotation(spawnPosition, Quaternion.identity);
    //    farthestRow = spawnPosition.y;

    //    transform.position = CheckpointPos;

    //    gameObject.SetActive(true);
    //    enabled = true;
    //    cooldown = false;
    //}
    //public void PlayerDied()
    //{
    //    // Disable control
    //    enabled = false;

    //    SetLives(lives - 1);

    //    if (lives > 0)
    //    {
    //        Invoke(nameof(Respawn), 1f);
    //    }
    //    else
    //    {
    //        Invoke(nameof(GameOver), 0f);
    //    }

    //}

    //private void SetLives(int lives)
    //{
    //    this.lives = lives;
    //    MylivesText.text = lives.ToString();
    //}

    //private void OnTriggerEnter2D(Collider2D other)
    //{

    //    bool hitObstacle = other.gameObject.layer == LayerMask.NameToLayer("Obstacles");

    //    if (enabled && hitObstacle)
    //    {
    //        PlayerDied();
    //    }
    //}

    //private void GameOver()
    //{
    //    SceneManager.LoadScene("GameOverScene");

    //}


}

