using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public Vector3 movementDirection;
    public float speed = 50;

    private void Start()
    {
        movementDirection = Vector3.zero;
    }

    private void Update()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            movementDirection = Vector3.right;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            movementDirection = Vector3.left;
        }
        else
        {
            movementDirection = Vector3.zero;
        }

        transform.position += movementDirection * speed * Time.deltaTime;
    }
}
