using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlanDisi : MonoBehaviour
{

    private GameObject karakter;
    // Start is called before the first frame update
    void Start()
    {
        karakter = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (karakter.transform.position.y < -90)
        {
            Debug.Log("düþtü düþtü");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
