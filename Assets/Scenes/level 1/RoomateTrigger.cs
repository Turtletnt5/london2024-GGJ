using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class RoomateTrigger : MonoBehaviour
{

    BoxCollider2D trigger;
    public GameObject ChoiceOverlay;
    public GameObject Playuer;
    public GameObject nextTrigger;
    public GameObject triggerLocation;

    SSC_movement input;
    Animator AController;


    // Start is called before the first frame update
    void Start()
    {
        trigger = GetComponent<BoxCollider2D>();
        AController = Playuer.GetComponent<Animator>();
        input = Playuer.GetComponent<SSC_movement>();
        if (input != null)
        {
            Debug.Log("input not null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        
        ChoiceOverlay.SetActive(true);
        input.deactiveInput();
        gameObject.SetActive(false);
        Instantiate(nextTrigger, triggerLocation.transform);
    }

}
