using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSpawn : MonoBehaviour
{

    PlayerLose player;
    public Transform checkpointspawn;

    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLose>();
        //player = GameObject.FindGameObjectWithTag("Checkpoint").GetComponent<TwoDCharacter_Movement>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        //if (other.CompareTag("Checkpoint"))
        {
            //player.UpdateCheckpoint(transform.position);
            player.UpdateCheckpoint(checkpointspawn.position);
        }
    }
}
