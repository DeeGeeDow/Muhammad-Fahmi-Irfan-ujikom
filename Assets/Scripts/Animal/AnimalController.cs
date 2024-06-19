using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class AnimalController : MonoBehaviour
{
    public float speed;
    public int HungerNeed;
    public int Score;
    public UnityEvent<int> AnimalFullEvent;
    
    private void Start()
    {
        
    }

    private void Update()
    {
        transform.position += new Vector3(0, 0, -1) * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Food")
        {
            AnimalFullEvent.Invoke(Score);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }else if(other.tag == "Animal Destroyer")
        {
            Destroy(gameObject);
        }
    }

}
