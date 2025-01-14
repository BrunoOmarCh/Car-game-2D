using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsSpawner_Level3 : MonoBehaviour
{
    public GameObject coinPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CoinSpawner());
    }

    // Update is called once per frame
    void Update()
    {

    }
    void CoinSpawn()
    {
        float rand = Random.Range(-6.60f, 7.2f);
        Instantiate(coinPrefab, new Vector3(rand, transform.position.y, transform.position.z), Quaternion.identity);
    }


    IEnumerator CoinSpawner()
    {
        while (true)
        {
            int time = Random.Range(1, 5);
            yield return new WaitForSeconds(time);
            CoinSpawn();
        }
    }
}
