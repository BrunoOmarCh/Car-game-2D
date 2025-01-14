using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosterSpawner_Level3 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Poste;
    void Start()
    {
        StartCoroutine(PosteSpawner());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void PosteSpawn()
    {
       
        Instantiate(Poste, new Vector3(0.55f, transform.position.y, transform.position.z), Quaternion.identity);
    }

    IEnumerator PosteSpawner()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(3);
            PosteSpawn();
        }
    }
}
