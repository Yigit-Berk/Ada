using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // TextMeshPro kullanıyorsanız bu eklemeyi yapın
using UnityEngine.SceneManagement;

public class EnterShip : MonoBehaviour
{
    public GameObject enterShipText; // TextMeshPro UI nesnesi

    private void Start()
    {
        // Yazının başlangıçta gizli olduğundan emin olun
        enterShipText.SetActive(false);
    }

    // Oyuncu BoxCollider2D'nin içine girdiğinde çalışacak
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Oyuncunun etiketi "Player" ise
        {
            enterShipText.SetActive(true); // Yazıyı aktif et
        }
    }

    // Oyuncu BoxCollider2D'den çıktığında çalışacak
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Oyuncunun etiketi "Player" ise
        {
            enterShipText.SetActive(false); // Yazıyı deaktif et
        }
    }

    private void Update()
    {
        // "F" tuşuna basıldığında ve yazı aktifken
        if (Input.GetKeyDown(KeyCode.F) && enterShipText.activeSelf)
        {
            Debug.Log("Gemiye bindiniz!"); // Konsola mesaj yaz
            SceneManager.LoadScene(4);
        }
    }
}
