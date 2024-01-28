using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomateTrigger : MonoBehaviour
{

    BoxCollider2D trigger;
    public GameObject ChoiceOverlay;

    // Start is called before the first frame update
    void Start()
    {
        trigger = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        ChoiceOverlay.SetActive(true);
    }

}
