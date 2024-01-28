//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class MoveCycle_Cars : MonoBehaviour
{
    public Vector2 direction = Vector2.right;

    public float VehicleSpeed = 1f;

    public int size = 1;

    private Vector3 LeftEdge;

    private Vector3 RightEdge;    

    private void Start()
    {
        LeftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        RightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);       
    }

    private void Update()
    {
        if (direction.x > 0 && (transform.position.x - size) > RightEdge.x)
        {
            Vector3 VechiclePosition = transform.position;
            VechiclePosition.x = LeftEdge.x - size;
            transform.position = VechiclePosition;
        }
        else if (direction.x < 0 && (transform.position.x + size) < LeftEdge.x)
        {
            Vector3 VechiclePosition = transform.position;
            VechiclePosition.x = RightEdge.x + size;
            transform.position = VechiclePosition;
        }
        else
        {
            transform.Translate(direction * VehicleSpeed * Time.deltaTime);
        }
    }
}
