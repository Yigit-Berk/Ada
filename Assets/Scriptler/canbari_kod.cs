using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cod : MonoBehaviour
{
    private Slider CanBari;
    private int can = 100;


    private void Awake()
    {
        CanBari = GameObject.Find("Slider").GetComponent<Slider>();

    }
    // Start is called before the first frame update
    void Start()
    {
        CanBari.maxValue = 100;
        CanBari.minValue = 0;
        CanBari.value = can;
        CanBari.wholeNumbers = true;// virgüllü deðerler almamasý için
        CanBari.fillRect.GetComponent<Image>().color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("20 birim can azaldý");
            can -= 20;
            CanBari.value = can;
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("15 birim can arttý");
            can += 15;
            CanBari.value = can;
        }
        if (can <=0)
        {
            Debug.Log("Karakter öldü");// ölünce gelicek kodlar.
        }
    }
}
