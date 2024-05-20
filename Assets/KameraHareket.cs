using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraHareket : MonoBehaviour
{

    Transform kamera;
    [SerializeField] Transform nesne;

    // Start is called before the first frame update
    void Start()
    {
        
        kamera = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        kamera.position = new Vector3(nesne.position.x, nesne.position.y+3, -20);
    }
}
