using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanDisconnect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void canDetach()
    {
        gameObject.transform.parent = null;
    }
}
