using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner4Level3 : MonoBehaviour
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
        float randXPos = Random.Range(-6.30f, -3.30f);
        Instantiate(car[rand], new Vector3(randXPos, transform.position.y, transform.position.z), Quaternion.Euler(0, 0, -90));
    }
    IEnumerator SpawnCars()
    {
        while (true)
        {
            int time = Random.Range(1, 5);
            yield return new WaitForSeconds(time);
            Cars();
        }
    }
}
