using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{

    public GameObject RamonItem;
    public GameObject PickedUpRamon_Txt;
    public GameObject TotheOtherSide_Txt;

    public GameObject PressE_Txt;


    // Start is called before the first frame update
    void Start()
    {
        PickedUpRamon_Txt.SetActive(false);
        PressE_Txt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PressE_Txt.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                RamonItem.SetActive(false);
                PickedUpRamon_Txt.SetActive(false);

                TotheOtherSide_Txt.SetActive(true);
                PressE_Txt.SetActive(false);
                GetItem.IsRamonFound = true;

            }
            //BringRamon_Txt.SetActive(false);
        }
    }
}
