using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner2Level3: MonoBehaviour
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
        float randXPos = Random.Range(1.80f, 7.20f);
        Instantiate(car[rand], new Vector3(randXPos, transform.position.y, transform.position.z), Quaternion.Euler(0, 0, 270));
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
