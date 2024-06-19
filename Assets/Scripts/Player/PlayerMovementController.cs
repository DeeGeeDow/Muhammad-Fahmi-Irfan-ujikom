using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public Vector3 movementDirection;
    public float speed = 50;
    private Animator animator;
    private void Start()
    {
        movementDirection = Vector3.zero;
        animator = GetComponent<Animator>();
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

        animator.SetFloat("moveToRight", movementDirection.x);
        transform.position += movementDirection * speed * Time.deltaTime;
    }
}
