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

    TwoDCharacter_Movement TwoDCharacter;

    //[SerializeField] private Text livesText;
    [SerializeField] Collider2D obstacles_;
    [SerializeField] private Text MylivesText;
    private int lives;

   // private int Lives => lives;
    private int CurrentLives = 3;



    void Start()
    {

       lives = 3;
       MylivesText.text = "Lives: " + lives;
        OnTriggerEnter2D(obstacles_);
        

    }
    private void NewGame()
    {

        SetLives(3);
        //NewLevel();
    }

    private void Respawn()
    {
        Losing();
        //OnTriggerEnter2D(Obstacles_);
        TwoDCharacter.Respawn();
    }

    private void Losing()
    {
        OnTriggerEnter2D(obstacles_);
    }

    public void OnTriggerEnter2D(Collider2D Obstacles)
    {
        if (Obstacles.tag == "Obstacles")
        {
            //MylivesText.text = "Lives : " - CurrentLives;
            Died();
        };
            //SceneManager.LoadScene("GameOverScene");
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
        MylivesText.text = "Lives: " + lives;
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

    private void GameOver()
    {
        //TwoDCharacter.gameObject.SetActive(false);
        //PlayerLose_.OnTriggerEnter2D(obstacles_);
        SceneManager.LoadScene("GameOverScene");
    }


}
