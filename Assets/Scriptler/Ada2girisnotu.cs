using TMPro;
using UnityEngine;
using UnityEngine.UI; // Eğer Text bileşeni kullanıyorsanız


public class ShowMessageOnTrigger : MonoBehaviour
{
     public TextMeshProUGUI messageUI; // UI Text veya TMP Text objesi
    private bool isPlayerInRange = false;

    void Start()
    {
        messageUI.gameObject.SetActive(false);
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.F))
        {
            fonksiyon();
        }
    }

     private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            Debug.Log("Notu Oku");
            // UI TextMeshPro nesnesini görünür yapın
            messageUI.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            // UI TextMeshPro nesnesini tekrar gizleyin
            messageUI.gameObject.SetActive(false);
        }
    }

    void fonksiyon()
    {
        // Not okuma işmei burada
        Debug.Log("Karakter notu okudu.");
        // UI TextMeshPro nesnesini tekrar gizleyin
        messageUI.gameObject.SetActive(false);
    }


}
