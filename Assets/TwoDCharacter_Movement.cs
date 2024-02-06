using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDCharacter_Movement : MonoBehaviour
{
    //private Vector3 spawnPosition;
    //private float farthestRow;

    //public Transform spawnPoint;

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            //transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            Move(Vector3.up);
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            //transform.rotation = Quaternion.Euler(0f, 0f, 180f);
            Move(Vector3.down);
        }

        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            Move(Vector3.left);
        }

        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            //transform.rotation = Quaternion.Euler(0f, 0f, -90f);
            Move(Vector3.right);
        }
    }

    private void Move(Vector3 Direction)
    {
        Vector3 Destination = transform.position += Direction;
        //Vector3 Destination = transform.position + Direction;
        //Collider2D barrier = Physics2D.OverlapBox(Destination, Vector2.zero, 0f, LayerMask.GetMask("Barrier"));
        //if (barrier != null)
        //{
        //    return;
        //}
    }

    public void Respawn()
    {
        // Stop animations
        //StopAllCoroutines();

        // Reset transform to spawn
        //transform.SetPositionAndRotation(spawnPosition, Quaternion.identity);
        //farthestRow = spawnPosition.y;

        //transform.position = spawnPoint.position;

        // Enable control
        //gameObject.SetActive(true);
        //enabled = true;
        //cooldown = false;
    }


}

