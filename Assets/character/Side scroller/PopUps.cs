using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopUps : MonoBehaviour
{

    
    public GameObject IntroPopupBouble;
    public GameObject ChoiceSelection;
    public GameObject Quest1;
    public GameObject Quest2;

    public AudioSource audioSource;
    public AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void introPopup()
    {
        Instantiate(IntroPopupBouble, transform);
        
    }

    public void enableChoiceScreen()
    {
        ChoiceSelection.SetActive(true);

    }

    public void completeQuest1()
    {
        TextMeshProUGUI quest1Text = Quest1.GetComponent<TextMeshProUGUI>();
        quest1Text.fontStyle = FontStyles.Strikethrough;
        Quest2.SetActive(true);
    }

    public void canSound()
    {
        audioSource.PlayOneShot(audioClip);
    }

}
