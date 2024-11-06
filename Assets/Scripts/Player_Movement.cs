using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public Transform transform;
    public float speed = 0.5f;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow)) 
        { 
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);            
        }

        if(Input.GetKey(KeyCode.LeftArrow)) 
        { 
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);            
        }
        // Manual way
        if(transform.position.x < -2.58f)
        {
            transform.position = new Vector3(-2.58f, transform.position.y, transform.position.z);
        }

          if(transform.position.x > 2.58f)
        {
            transform.position = new Vector3(2.58f, transform.position.y, transform.position.z);
        }
        
    
       /* /// Unity Inbuilt feature
        Vector3 pos = transform.position; 
        pos.x= Mathf.Clamp(pos.x, 1.8f, 1.8f); 
        transform.position = pos;
*/
    }
}
