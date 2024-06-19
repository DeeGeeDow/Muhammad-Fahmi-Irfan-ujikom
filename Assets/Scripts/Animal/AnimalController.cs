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
    private int hunger = 0;
    
    private void Start()
    {
        hunger = 0;
    }

    private void Update()
    {
        transform.position += new Vector3(0, 0, -1) * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Food")
        {
            hunger += other.GetComponent<FoodController>().hungerValue;
            if(hunger >= HungerNeed)
            {
                GameManager.Instance.Score += Score;
                Destroy(gameObject);
            }
            Destroy(other.gameObject);

        }else if(other.tag == "Animal Destroyer")
        {
            Destroy(gameObject);
        }
    }

}
