using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner1_Level2 : MonoBehaviour
{
    public GameObject[] car;
    void Start()
    {
        StartCoroutine(SpawnCars());
    }

    void Update()
    {

    }

    void Cars()
    {
        int rand = Random.Range(0, car.Length);
        float randXPos = Random.Range(-2.47f, -0.8f);
        Instantiate(car[rand], new Vector3(randXPos, transform.position.y, transform.position.z), Quaternion.Euler(0, 0, -90));
    }
    IEnumerator SpawnCars()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Cars();
        }
    }

}