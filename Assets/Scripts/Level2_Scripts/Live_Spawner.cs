using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Live_Spawner : MonoBehaviour
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
        float rand = Random.Range(-1.8f, 1.8f);
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
