using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    //public Text MyscoreText;
    [SerializeField] private Text MyscoreText;
    private int ScoreNum;
    private int MaxScore = 1;
    public bool WinCondition = false;

    // Start is called before the first frame update
    void Start()
    {

        ScoreNum = 0;
        MyscoreText.text = "Ramon : " + ScoreNum;

    }


    private void OnTriggerEnter2D(Collider2D Food)
    {

        if (Food.tag == "Food")
        {
            ScoreNum += 1;
            Destroy(Food.gameObject);
            MyscoreText.text = "Ramon : Collected " + ScoreNum;
        }

        if (ScoreNum >= MaxScore)
        {
            WinCondition = true;
        }

        if (WinCondition == true)
        {
            SceneManager.LoadScene("GameOverScene");
        }

    }
}
