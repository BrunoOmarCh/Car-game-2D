using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveSpawnerLevel3 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Live;
    void Start()
    {
        StartCoroutine(LiveSpawner());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LiveSpawn()
    {
        float rand = Random.Range(-6.30f, 7.20f);
        Instantiate(Live, new Vector3(rand, transform.position.y, transform.position.z), Quaternion.identity);
    }

    IEnumerator LiveSpawner()
    {
        while (true)
        {
            int time = Random.Range(10, 15);
            yield return new WaitForSeconds(time);
            LiveSpawn();
        }
    }
}
