using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TwoDCharacter_Movement : MonoBehaviour
{
    private Vector3 spawnPosition;
    //private float farthestRow;

    //public Transform spawnPoint;

    // Update is called once per frame

    //public GameObject RespawnPoint;
    //public GameObject Player;
    private SpriteRenderer spriteRenderer;

    //[SerializeField] Collider2D obstacles_;
    //[SerializeField] private Text MylivesText;
    private int lives;

    //PlayerLose player__;

    private float farthestRow;
    private bool cooldown;

    //void Start()
    //{

    //    //lives = 4;
    //    //MylivesText.text = "Lives: " + lives; 
    //    spawnPosition = transform.position;
    //}

    private void Awake()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        spawnPosition = transform.position;
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            //transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            Move(Vector3.up);
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            //transform.rotation = Quaternion.Euler(0f, 0f, 180f);
            Move(Vector3.down);
        }

        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            Move(Vector3.left);
        }

        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            //transform.rotation = Quaternion.Euler(0f, 0f, -90f);
            Move(Vector3.right);
        }
    }

    private void Move(Vector3 Direction)
    {
        if (cooldown) return;
        Vector3 Destination = transform.position + Direction;
        //Vector3 Destination = transform.position + Direction;
        Collider2D barrier = Physics2D.OverlapBox(Destination, Vector2.zero, 0f, LayerMask.GetMask("Barrier"));
        Collider2D obstacle = Physics2D.OverlapBox(Destination, Vector2.zero, 0f, LayerMask.GetMask("Obstacles"));
        if (barrier != null)
        {
            return; 
        }

        if (obstacle != null)
        {
            transform.position = Destination;
            PlayerDied();
        }

        StartCoroutine(Leap(Destination));
    }

    private IEnumerator Leap(Vector3 destination)
    {
        Vector3 startPosition = transform.position;
        float elapsed = 0f;
        float duration = 0.125f;

        // Set initial state
        // spriteRenderer.sprite = leapSprite;
        //cooldown = true;

        while (elapsed < duration)
        {
            // Move towards the destination over time
            float t = elapsed / duration;
            transform.position = Vector3.Lerp(startPosition, destination, t);
            //Player.transform.position = Vector3.Lerp(startPosition, destination, t);
            elapsed += Time.deltaTime;
            yield return null;
        }



        //player__.Losing();

        // Set final state
        transform.position = destination;
        //spriteRenderer.sprite = idleSprite;
        cooldown = false;
    }

    public void Respawn()
    {
        //Player.transform.position = RespawnPoint.transform.position;
        //GameManager.Instance.Died();

        //OnTriggerEnter2D(obstacles_);

        transform.SetPositionAndRotation(spawnPosition, Quaternion.identity);
        farthestRow = spawnPosition.y;

        gameObject.SetActive(true);
        enabled = true;
        cooldown = false;
    }

 

    //private void SetLives(int lives)
    //{
    //    this.lives = lives;
    //    MylivesText.text = "Lives: " + lives;
    //}


    public void PlayerDied()
    {
        // Disable control
        enabled = false;

        // Display death sprite
        transform.rotation = Quaternion.identity;
        GameManager.Instance.Died();
     
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (Obstacles.tag == "Obstacles")
        //{
        //    //MylivesText.text = "Lives : " - CurrentLives;
        //    Died();
        //};

        //if (other.gameObject.CompareTag("Player") || other.tag == "Obstacles")
        //if (other.tag == "Obstacles")
        //{
        //    //Player.transform.position = RespawnPoint.transform.position;
        //    //Respawn();
        //    PlayerDied();
        //}
        bool hitObstacle = other.gameObject.layer == LayerMask.NameToLayer("Obstacles");

        if (enabled && hitObstacle)
        {
            PlayerDied();
        }
        //SceneManager.LoadScene("GameOverScene");
    }

    private void GameOver()
    {
        //TwoDCharacter.gameObject.SetActive(false);
        //PlayerLose_.OnTriggerEnter2D(obstacles_);
        SceneManager.LoadScene("GameOverScene");
        
    }


}

