using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> animals = new List<GameObject>();
    public float spawnInterval;
    public float LeftMostPosition = -12;
    public float RightMostPosition = 12;
    private float timer = 0;
    private void Update()
    {
        if(timer < spawnInterval)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            Spawn();
        }
    }

    void Spawn()
    {
        int animal_idx = Random.Range(0, animals.Count);
        float position = Random.Range(LeftMostPosition, RightMostPosition);
        GameObject animal = Instantiate(animals[animal_idx], transform.position + Vector3.right*position, Quaternion.Euler(0,180,0));
    }
}
