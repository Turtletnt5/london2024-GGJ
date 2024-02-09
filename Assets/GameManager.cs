using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour

{
    public static GameManager Instance { get; private set; }
    //[SerializeField] private GameManager gm;

   // [SerializeField] private Home[] homes;
    [SerializeField] private TwoDCharacter_Movement Player;
    //[SerializeField] private GameObject gameOverMenu;
    //[SerializeField] private Text timeText;
    [SerializeField] private Text MylivesText;
    //[SerializeField] private Text scoreText;

    //[SerializeField] private GetItem item;
    [SerializeField] private GameObject item;
    private CheckpointSpawn Spawn;
    //[SerializeField] public GameObject target;

    private GetItem quest;
    private Vector3 spawnPosition;
    private float farthestRow;

    //private int lives;
    //private int score;
    //private int time;

    public int Lives => lives;
    //public int Score => score;
    //public int Time => time;

    private int lives;

    //private Vector3 spawnPositionPlayer;

    //public bool isGameActive;

    private void Awake()
    {
        //Player = GetComponent<TwoDCharacter_Movement>();
        //MylivesText = GetComponent<Text>();
        //item = GetComponent<GameObject>();

        //Player = new TwoDCharacter_Movement();
        ////MylivesText = gameObject.AddComponent<Text>();
        //MylivesText = gameObject.AddComponent<Text>();
        //item = new GameObject();

        if (Instance != null)
        {
            // DestroyImmediate(gameObject);
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            Application.targetFrameRate = 60;
            DontDestroyOnLoad(gameObject);
        }
    }

    //private void Awake()
    //{

    //    //spriteRenderer = GetComponent<SpriteRenderer>();
    //    //CheckpointPos = transform.position;
    //    //spawnPositionPlayer = transform.position;
    //    Player = GetComponent<TwoDCharacter_Movement>();
    //    MylivesText = GetComponent<Text>();
    //    item = GetComponent<GameObject>();

    //}

    //void StartGamw()
    //{
    //    MylivesText = GetComponent<Text>();
    //}


    private void Start()
    {
        //lives = 4;
        //MylivesText.text = "Lives: " + lives; // Display Player's lives from UI.
        //Player = GetComponent<TwoDCharacter_Movement>();

        //Player = new TwoDCharacter_Movement();
        //Player = GetComponent<TwoDCharacter_Movement>();
        //MylivesText = gameObject.AddComponent<Text>();
        //MylivesText = gameObject.AddComponent<Text>();
       // item = new GameObject();
        //item = GetComponent<GameObject>();

        NewGame();
        //spawnPositionPlayer = transform.position;
        //transform.SetPositionAndRotation(spawnPosition, Quaternion.identity);
        //farthestRow = spawnPositionPlayer.y;
        //gameOverMenu.SetActive(false);
    }

    private void NewGame()
    {
        //gameOverMenu.SetActive(false);
        //Player.RespawnfromStart();
        // GameOver();
        //SetScore(0);
        SetLives(3);
        //item.gameObject.SetActive(true);
        //Player.gameObject.SetActive(true);
        //quest.gameObject.SetActive(true);
        
        //GetItem.IsRamonFound = false;

        //Spawn.gameObject.SetActive(true);
        //NewLevel();
        NewLevel();


        //Player.RespawnfromStart();
      
        //spawnPosition = transform.position;
    }

    private void NewLevel()
    {


        RespawnPlayer();

        //Player.RespawnfromStart();
        item.gameObject.SetActive(true);
        //Player.gameObject.SetActive(true);
        //GetItem.IsRamonFound = true;

    }

    private void RespawnPlayer()
    {
        //Player.Respawn();
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

        //if (lives > 0)
        //{

        //}
        //else
        //{
        //    Invoke(nameof(GameOver), 0f);
        //}

    }

    private void GameOver()
    {

        //Player.gameObject.SetActive(false);        
        //gameOverMenu.SetActive(true);

        SceneManager.LoadScene("GameOverScene");
        //StopAllCoroutines();
        //StartCoroutine(CheckForPlayAgain());
        //NewGame();

    }
    private void SetLives(int lives)
    {
        this.lives = lives;
        MylivesText.text = lives.ToString(); 
    }

    //void Reset()
    //{
    //    if (!target)
    //        target = GameObject.FindWithTag("Player");

    //}

    //private IEnumerator CheckForPlayAgain()
    //{
    //    bool playAgain = false;

    //    while (!playAgain)
    //    {
    //        if (Input.GetKeyDown(KeyCode.Return))
    //        {
    //            playAgain = true;

    //        }

    //        yield return null;
    //    }
    //    //Reset();
    //    //SceneManager.LoadScene("Level2Scene");
    //    NewGame();
     
    //}
}
