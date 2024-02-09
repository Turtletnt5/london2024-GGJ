using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{

    // Variables.

    // Name of the item.
    public GameObject RamonItem; 

    // When the Ramon is picked up.
    public GameObject PickedUpRamon_Txt;

    // To display the last objective.
    public GameObject TotheOtherSide_Txt;

    // To press E to collect Ramon.
    public GameObject PressE_Txt;


    // Start is called before the first frame update
    void Start()
    {

        // To show the objective after player collect the Ramon.
        TotheOtherSide_Txt.SetActive(false);

        // Display Pressing E to interact.
        PressE_Txt.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        // Tagging the player for the Trigger.
        if (collision.gameObject.tag == "Player")
        {
            // When the player press E to pick up Ramon.
            PressE_Txt.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                // When the Ramon is active before the player collects it.
                RamonItem.SetActive(false);

                // When the Ramon is collected.
                PickedUpRamon_Txt.SetActive(false); 

                // Displaying the text when the player have to Press E to collect the Ramon.
                PressE_Txt.SetActive(false); 

                // Displaying another objective to the goal.
                TotheOtherSide_Txt.SetActive(true);
                
                // After when the Ramon is collected.
                GetItem.IsRamonFound = true; 

            }
        }
    }
}
