using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1ChoiceAnimations : MonoBehaviour
{

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
       animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //plays bucket of water animation
    void bucketOfWater()
    {
        animator.SetTrigger("WaterBucket");
        animator.ResetTrigger("WaterBucket");
    }

    //plays alarm clock animation
    void AlarmClock()
    {

    }

    //plays chip can animation
    void ChipCan()
    {

    }

}
