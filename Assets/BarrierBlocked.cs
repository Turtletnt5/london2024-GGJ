using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierBlocked : MonoBehaviour
{
    // Start is called before the first frame update

    //public GameObject RespawnPoint;
    public GameObject Player;

    private void OnTriggerEnter2D(Collider2D Barrier, Vector3 Direction)
    {
        Barrier = Physics2D.OverlapBox(Direction, Vector2.zero, 0f, LayerMask.GetMask("Barrier"));
        if (Barrier.gameObject.CompareTag("Player") || Barrier.tag != "Barrier")
        {
            return;
        }
    }
}
