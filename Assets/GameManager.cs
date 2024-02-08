using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour

{
    public static GameManager Instance { get; private set; }

   // [SerializeField] private Home[] homes;
    [SerializeField] private TwoDCharacter_Movement Player;
    [SerializeField] private GameObject gameOverMenu;
    //[SerializeField] private Text timeText;
    [SerializeField] private Text MylivesText;
    //[SerializeField] private Text scoreText;

    //[SerializeField] private GetItem item;
    [SerializeField] private GameObject item;

    //private int lives;
    //private int score;
    //private int time;

    public int Lives => lives;
    //public int Score => score;
    //public int Time => time;

    private int lives;

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
            Application.targetFrameRate = 60;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        //lives = 4;
        //MylivesText.text = "Lives: " + lives; // Display Player's lives from UI.
        NewGame();
    }

    private void NewGame()
    {
        gameOverMenu.SetActive(false);
       // GameOver();
        //SetScore(0);
        SetLives(3);
        //NewLevel();
        NewLevel();
        item.gameObject.SetActive(true);
    }

    private void NewLevel()
    {


        RespawnPlayer();
        
    }

    private void RespawnPlayer()
    {
        Player.Respawn();
        StopAllCoroutines();
        //StopAllCoroutines();
        //StartCoroutine(Timer(30));
    }

    public void Died()
    {
        SetLives(lives - 1);

        if (lives > 0)
        {
            Invoke(nameof(RespawnPlayer), 1f);
        }
        else
        {
            Invoke(nameof(GameOver), 0f);
        }
    }

    private void GameOver()
    {

        Player.gameObject.SetActive(false);
        gameOverMenu.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(CheckForPlayAgain());
        //NewGame();

    }
    private void SetLives(int lives)
    {
        this.lives = lives;
        MylivesText.text = lives.ToString(); 
    }

    private IEnumerator CheckForPlayAgain()
    {
        bool playAgain = false;

        while (!playAgain)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                playAgain = true;
            }

            yield return null;
        }

        NewGame();
    }
}
