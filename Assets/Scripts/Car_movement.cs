
using System.Collections.Generic;

using UnityEngine;

public class Car_Movement : MonoBehaviour
{
    //public Transform transform;  Util para versiones anteriores < 2021
    public float speed = 5f;

    void Start()

    {
        // transform = GetComponent<Transform>();   Util para versiones anteriores < 2021
    }

    void Update()
    {
        transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
        if(transform.position.y <= -10)
        {
            Destroy(gameObject);
        }
    }
}