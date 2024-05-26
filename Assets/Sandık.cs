using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Sandik : MonoBehaviour
{
    public Animator anim;
    public string Diyalog;
    public TextMeshProUGUI textI;
    private bool oyuncuYakinda = false;
    public GameObject canIksiriPrefab; // Can iksiri prefabı
    private bool sandikAcildi = false; // Sandık açıldı mı kontrol et 

    private void Update()
    {
        if (oyuncuYakinda && Input.GetKeyDown(KeyCode.F) && !sandikAcildi)
        {
            SandikAcKapa();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // gelen obje tagı player ise
        {
            oyuncuYakinda = true;
            Debug.Log("Oyuncu sandık alanına girdi");
            textI.text = Diyalog;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // gelen obje tagı player ise
        {
            oyuncuYakinda = false;
            Debug.Log("Oyuncu sandık alanından çıktı");
            textI.text = " ";
            anim.SetBool("acikMi", false);
        }
    }

    private void SandikAcKapa()
    {
        sandikAcildi = true; // Sandık artık açıldı

        bool acikMi = anim.GetBool("acikMi");
        anim.SetBool("acikMi", !acikMi);

        if (!acikMi)
        {
            Debug.Log("Sandık açıldı");
            Vector3 spawnPosition = transform.position + Vector3.up*2; // Sandık transformunun pozisyonuna iki birim yukarısına spawn et
            Instantiate(canIksiriPrefab, spawnPosition, Quaternion.identity); // Can iksirini oluştur
        }
        else
        {
            Debug.Log("Sandık kapatıldı");
        }
    }
}
