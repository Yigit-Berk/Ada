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

    [SerializeField]Animator animasyonDurumu;
    //SpriteRenderer goruntu;

    private enum Durumlar
    {
        bekleme,
        kosma,
        dusme,
        ziplama
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        carpma = this.GetComponent<BoxCollider2D>();
        animasyonDurumu = this.GetComponent<Animator>();
        //goruntu = this.GetComponent<SpriteRenderer>();
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
        xYon = Input.GetAxisRaw("Horizontal");
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
        Durumlar durumEnum;

        if (xYon == 0)
        {
            durumEnum = Durumlar.bekleme; // 0
        }
        else
        {
            durumEnum = Durumlar.kosma; // 1
            //goruntu.flipX = xYon < 0;
        }

        if (rb.velocity.y > 0.1f)
        {
            durumEnum = Durumlar.ziplama; // 3
        }
        else if (rb.velocity.y < -0.1f)
        {
            durumEnum = Durumlar.dusme; // 2
        }

        animasyonDurumu.SetInteger("Durum", (int)durumEnum);
    }
}
