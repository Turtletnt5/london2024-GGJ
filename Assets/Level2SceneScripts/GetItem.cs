using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetItem : MonoBehaviour
{
    // Variables.

    // Displaying objective for the player.
    public GameObject GetRamon_Txt;

    // Trigger for the Ramon when collect.
    public GameObject RamonItem;

    // Making a bool to make sure if the Ramon is found.
    public static bool IsRamonFound; 

    // Start is called before the first frame update
    void Start()
    {

        // When the Ramon is not collected yet.
        IsRamonFound = false;

        // Displaying Quest UI.
        GetRamon_Txt.SetActive(false); 

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        // Tagging the player for the Trigger.
        if (collision.gameObject.tag == "Player")
        {

            // When the Ramon is Collected.
            if (IsRamonFound == false)
            {

                // Displaying the next objective.
                GetRamon_Txt.SetActive(true); 

            }

        }

        // If the player didn't collect the Ramon, it doesn't take to the Win Scene. 
        // Player must collect Ramon to win.
        if(IsRamonFound == true)
        {

            // Goes to the Win Scene.
            SceneManager.LoadScene("WinScene");
        }
    }
}
