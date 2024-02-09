using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetItem : MonoBehaviour
{

    public GameObject GetRamon_Txt;
    public GameObject RamonItem;
    public Collider2D interact;

    public static bool IsRamonFound;

    // Start is called before the first frame update
    void Start()
    {
        IsRamonFound = false;
        GetRamon_Txt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (IsRamonFound == false)
            {
                GetRamon_Txt.SetActive(true);
            }
        }

        if(IsRamonFound == true)
        {
            SceneManager.LoadScene("WinScene");
        }
    }

    public void RespawnfromStart()
    {
        OnTriggerStay2D(interact);
    }
}
