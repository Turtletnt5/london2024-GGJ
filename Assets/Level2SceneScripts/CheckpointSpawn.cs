using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSpawn : MonoBehaviour
{

    // Variables for functions below.

    // Need to make a ref for the tag by having GetComponent function.
    TwoDCharacter_Movement player;

    // For the position of the checkpoint spawn after triggered it.
    public Transform checkpointspawn;

    // Start is called before the first frame update
    private void Awake()
    {
        // To tag the Player.
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<TwoDCharacter_Movement>(); 
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Tagging player for the Checkpoint Gameobject.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //player.UpdateCheckpoint(transform.position);
            player.UpdateCheckpoint(checkpointspawn.position);
        }
    }
}
