using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ev_Giris : MonoBehaviour
{
     public TextMeshProUGUI enterHouseText; // UI TextMeshPro öğesini buraya sürükleyin.
    private bool isPlayerInside = false;

    void Start()
    {
        // TextMeshPro nesnesini başlangıçta gizli hale getirin
        enterHouseText.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
            Debug.Log("Eve gir");
            // UI TextMeshPro nesnesini görünür yapın
            enterHouseText.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
            // UI TextMeshPro nesnesini tekrar gizleyin
            enterHouseText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (isPlayerInside && Input.GetKeyDown(KeyCode.F))
        {
            EnterHouseFunction();
        }
    }

    void EnterHouseFunction()
    {
        // Eve girme işlemini burada tanımlayın
        Debug.Log("Karakter eve girdi.");
        // UI TextMeshPro nesnesini tekrar gizleyin
        enterHouseText.gameObject.SetActive(false);
    }


}
