using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class canbari_kod : MonoBehaviour
{
    private Slider CanBari;
    public int Heal = 100;

    private void Awake()
    {
        CanBari = GameObject.Find("Slider").GetComponent<Slider>();
    }

    void Start()
    {
        CanBari.maxValue = 100;
        CanBari.minValue = 0;
        CanBari.value = Heal;
        CanBari.wholeNumbers = true; // Virgüllü değerler almaması için
        CanBari.fillRect.GetComponent<Image>().color = Color.red;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("20 birim can azaldi");
            Heal -= 20;
            CanBari.value = Heal;
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("15 birim can artti");
            Heal += 15;
            CanBari.value = Heal;
        }
        if (Heal <= 0)
        {
            Debug.Log("Karakter oldu"); // Ölünce gelicek kodlar.
            // Ölüm animasyonu ve diğer işlemler
        }
    }

    public void playerHealth(int amount)
    {
        Heal += amount;
        if (Heal > 100)
        {
            Heal = 100; // Maksimum canı aşmaması için
        }
        CanBari.value = Heal;
        Debug.Log("Can arttı: " + amount);
    }
}
