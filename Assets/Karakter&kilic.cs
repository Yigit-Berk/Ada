using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterKontrol : MonoBehaviour
{
    public GameObject kilicPrefab; // Kılıç prefabı
    public Transform elNoktasi; // Karakterin elini temsil eden nokta

    private GameObject mevcutKilic; // Mevcut kılıç referansı

    void Start()
    {
        if (kilicPrefab == null)
        {
            Debug.LogError("KilicPrefab referansı atanmamış!");
            return;
        }

        if (elNoktasi == null)
        {
            Debug.LogError("ElNoktasi referansı atanmamış!");
            return;
        }

        KlicEkle(); // Oyunun başlangıcında kılıcı ekle
    }

    void KlicEkle()
    {
        Debug.Log("KlicEkle fonksiyonu çağrıldı."); // Debug mesajı
        if (mevcutKilic != null)
        {
            Destroy(mevcutKilic); // Eğer önceden bir kılıç varsa yok et
            Debug.Log("Mevcut kılıç yok edildi."); // Debug mesajı
        }

        mevcutKilic = Instantiate(kilicPrefab, elNoktasi.position, elNoktasi.rotation); // Kılıcı oluştur
        mevcutKilic.transform.SetParent(elNoktasi); // Kılıcı el noktasına child olarak ekle

        // Kılıcın aktif olup olmadığını kontrol et
        if (!mevcutKilic.activeInHierarchy)
        {
            Debug.Log("Kılıç prefabı aktif değil.");
            mevcutKilic.SetActive(true); // Kılıcı aktif hale getir
        }

        Debug.Log("Kılıç instantiate edildi ve el noktasına eklendi."); // Debug mesajı
    }
}
