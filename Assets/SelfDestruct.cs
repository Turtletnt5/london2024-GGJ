using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    // Start is called before the first frame update
    public float DelayTime = 5;
    void Start()
    {
        Destroy(gameObject,DelayTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
