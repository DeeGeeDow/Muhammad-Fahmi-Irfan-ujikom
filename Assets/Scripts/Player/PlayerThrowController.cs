using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrowController : MonoBehaviour
{
    public GameObject food;
    // Start is called before the first frame update
    void Start()
    {
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
            Instantiate(food, transform.position, Quaternion.identity);
        }
    }
}
