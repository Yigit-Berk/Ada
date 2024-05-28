using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Karakter_Kilic1 : MonoBehaviour
{
    public static Karakter_Kilic1 Instance;
    public GameObject kilicPrefab; // Kılıç prefabı
    public Transform elNoktasi; // Karakterin elini temsil eden nokta
    public Animator animator; // Karakterin animator bileşeni

    private GameObject mevcutKilic; // Mevcut kılıç referansı
    private bool saldiriyaHazir = true; // Saldırı yapmaya hazır mı kontrolü


    private void Awake()
    {
        if (Instance == null)
            Instance = this;

    }


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

        if (animator == null)
        {
            Debug.LogError("Animator referansı atanmamış!");
            return;
        }

        KlicEkle(); // Oyunun başlangıcında kılıcı ekle
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && saldiriyaHazir) // Sol fare tıklamasını ve saldırıya hazır olduğunu kontrol et
        {
            Saldir();
            saldiriyaHazir = true; // Saldırı yapıldığını işaretle
            animator.SetBool("bekleme",true);
            
        }
    }

   public void KlicEkle()
    {
        Debug.Log("KlicEkle fonksiyonu çağrıldı."); // Debug mesajı
        if (mevcutKilic != null)
        {
            Destroy(mevcutKilic); // Eğer önceden bir kılıç varsa yok et
            Debug.Log("Mevcut kılıç yok edildi."); // Debug mesajı
        }

        
        Quaternion rotation = elNoktasi.rotation * Quaternion.Euler(0, 0, 0);
        mevcutKilic = Instantiate(kilicPrefab, elNoktasi.position, rotation); // Kılıcı oluştur
        mevcutKilic.transform.SetParent(elNoktasi); // Kılıcı el noktasına child olarak ekle

        // Kılıcın aktif olup olmadığını kontrol et
        if (!mevcutKilic.activeInHierarchy)
        {
            Debug.Log("Kılıç prefabı aktif değil.");
            mevcutKilic.SetActive(true); // Kılıcı aktif hale getir
        }

        Debug.Log("Kılıç instantiate edildi ve el noktasına eklendi."); // Debug mesajı
    }

    void Saldir()
{
     Debug.Log("Saldir fonksiyonu çağrıldı."); // Debug mesajı
    if (saldiriyaHazir)
    {
        animator.SetTrigger("Attack"); // Attack parametresini tetikle
        saldiriyaHazir = false; // Saldırı yapıldığını işaretle
    }
    
}
}
