using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierBlocked : MonoBehaviour
{
    // Start is called before the first frame update

    //public GameObject RespawnPoint;
    public GameObject Player;
    public GameObject BarrierBlocked_;
    [SerializeField] Collider2D Barrier_;

    private void OnTriggerEnter2D(Collider2D Barrier, Vector3 Direction)
    {
        Barrier = Physics2D.OverlapBox(Direction, Vector2.zero, 0f, LayerMask.GetMask("Barrier"));
        if (Player.gameObject.CompareTag("Player") || Barrier.gameObject.CompareTag("Barrier"))
        {
            if (Barrier.tag == "Barrier") { 
                if(BarrierBlocked_ != null) 
                {
                    //Player.transform.position = BarrierBlocked_.transform.position;
                    return;
                }
            }
        }
    }
}
