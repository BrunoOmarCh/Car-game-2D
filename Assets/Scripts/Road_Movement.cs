using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Road_Movement : MonoBehaviour
{
    public Renderer meshRenderer;
    public float speed = 5f;

    void Update()
    {
        if (meshRenderer != null && meshRenderer.material != null)
        {
            Vector2 offset = meshRenderer.material.mainTextureOffset;
            offset += new Vector2(0, speed * Time.deltaTime);
            offset.y %= 5; // Mantiene el desplazamiento en el rango [0, 1]
            meshRenderer.material.mainTextureOffset = offset;
        }
        else
        {
            Debug.LogWarning("El Renderer o Material no está asignado.");
        }
    }
}
