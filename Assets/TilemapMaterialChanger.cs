using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapMaterialChanger : MonoBehaviour
{
    // Start is called before the first frame update
    public Material BackgroundMaterial;

    void Start()
    {
        TilemapRenderer tilemapRenderer = GetComponent<TilemapRenderer>();

        if (tilemapRenderer != null && BackgroundMaterial != null)
        {
            tilemapRenderer.material = BackgroundMaterial;
            Debug.Log("Material successfully assigned to the Tilemap.");
        }
        else
        {
            Debug.LogError("TilemapRenderer or BackgroundMaterial is missing!");
        }
    }
}
