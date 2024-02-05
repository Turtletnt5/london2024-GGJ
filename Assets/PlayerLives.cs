using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLives : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TwoDCharacter_Movement TwoDCharacter;
    [SerializeField] private PlayerLose PlayerLose_;
    [SerializeField] private Text livesText;
    [SerializeField] Collider2D obstacles_;
    //[SerializeField] GameOverScreen gameover;
    private int lives;

    public int Lives => lives;

    //public int livesCounter;
    //public Text livesText;

    void Start()
    {
        NewGame();
        //livesCounter = PlayerPrefs.GetInt("CurrentLives");

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void NewGame()
    {
   
        SetLives(3);
        //NewLevel();
    }

    private void Respawn()
    {
   
        PlayerLose_.OnTriggerEnter2D(obstacles_);
        TwoDCharacter.Respawn();
    }

    //private void NewLevel()
    //{

    //    Respawn();
    //}

    private void GameOver()
    {
        TwoDCharacter.gameObject.SetActive(false);
        //PlayerLose_.OnTriggerEnter2D(obstacles_);
        SceneManager.LoadScene("GameOverScene");
    }

    public void Died()
    {
        SetLives(lives - 1);

        if (lives > 0)
        {
            Invoke(nameof(Respawn), 1f);
        }
        else
        {
            Invoke(nameof(GameOver), 1f);
        }
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
        livesText.text = lives.ToString();
        //livesText.text = " X: " + TakeLife();
    }

    //public void TakeLife()
    //{
    //    livesCounter--;
    //    PlayerPrefs.SetInt("CurrentLives", livesCounter);
    //}

}
