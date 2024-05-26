using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hareket : MonoBehaviour
{
    // Global Değişkenler
    float xYon;

    [SerializeField] int hiz = 8;
    [SerializeField] int ziplamaHiz = 10;
    [SerializeField] LayerMask katman;

    Rigidbody2D rb;
    BoxCollider2D carpma;

    [SerializeField] Animator animasyonDurumu;
    // SpriteRenderer goruntu;

    private enum Durumlar
    {
        bekleme = 0,
        kosma = 1,
        ziplama = 2,
        yürüme=3,
        hasar = 4,
        kilicAtak = 5,
        tabancaAtak = 6,
        yenilgi = 7
        
    }

    private Durumlar mevcutDurum;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        carpma = this.GetComponent<BoxCollider2D>();
        animasyonDurumu = this.GetComponent<Animator>();
        mevcutDurum = Durumlar.bekleme;
        xYon = Input.GetAxisRaw("Horizontal");
        animasyonDurumu.SetFloat("Speed",Mathf.Abs(xYon));
    }

    // Update is called once per frame
    void Update()
    {
        yatayHareket();
        ziplama();
        AnimasyonDurumlari();
    }

    private void yatayHareket()
    {
        rb.velocity = new Vector2(xYon * hiz, rb.velocity.y);
    }

    private void ziplama()
    {
        if (Input.GetButtonDown("Jump") && YerdeMi())
        {
            rb.velocity = new Vector2(rb.velocity.x, ziplamaHiz);
        }
    }

    private bool YerdeMi()
    {
        return Physics2D.BoxCast(carpma.bounds.center, carpma.bounds.size, 0f, Vector2.down, 0.2f, katman);
    }

    private void AnimasyonDurumlari()
    {
        Durumlar yeniDurum = Durumlar.bekleme; // Varsayılan durumu bekleme olarak ayarlayın

        if (!YerdeMi())
        {
            yeniDurum = Durumlar.ziplama; // Zıplama durumu
        }
        else if (xYon != 0)
        {
            yeniDurum = Durumlar.yürüme; // Koşma durumu
        }

        // Animasyon durumunu sadece değiştiğinde güncelle
        if (mevcutDurum != yeniDurum)
        {
            mevcutDurum = yeniDurum;
            animasyonDurumu.SetInteger("Durum", (int)mevcutDurum);
        }
    }
}
