using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrowController : MonoBehaviour
{
    public GameObject food;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Throw();
    }

    void Throw()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Instantiate(food, transform.position + new Vector3(0,1,0), Quaternion.identity);
            animator.SetTrigger("throw");
        }
    }
}
