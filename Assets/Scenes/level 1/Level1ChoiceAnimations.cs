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

    //plays bucket of alarmclock sound
    public AudioSource AlarmAudioSource;
    public AudioClip AlarmAudioClip;


    public void AlarmClockSound()
    {
        AlarmAudioSource.PlayOneShot(AlarmAudioClip);
    }

}
