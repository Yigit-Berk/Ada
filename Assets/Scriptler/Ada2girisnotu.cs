using UnityEngine;
using UnityEngine.UI; // Eğer Text bileşeni kullanıyorsanız
//using TMPro; // Eğer TextMeshPro kullanıyorsanız

public class ShowMessageOnTrigger : MonoBehaviour
{
    public GameObject messageUI; // UI Text veya TMP Text objesi
    private bool isPlayerInRange = false;

    void Start()
    {
        messageUI.SetActive(false); // Başlangıçta mesajı gizle
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.F))
        {
            // Buraya F tuşuna basıldığında yapılacak işlemleri ekleyebilirsiniz
            Debug.Log("Not okunuyor...");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Oyuncu karakterinizin tag'ı "Player" olmalı
        {
            messageUI.SetActive(true);
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            messageUI.SetActive(false);
            isPlayerInRange = false;
        }
    }
}