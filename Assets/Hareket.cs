using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hareket : MonoBehaviour
{

    //Global Deðiþkenler
    float xYon;

    [SerializeField] int hiz = 8;
    [SerializeField] int ziplamaHiz = 10;
    [SerializeField] LayerMask katman;
    
    Rigidbody2D rb;
    BoxCollider2D carpma;

    Animator animasyonDurumu;

    SpriteRenderer goruntu;

    private enum Durumlar
    {
        bekleme,
        kosma,
        dusme,
        ziplama
    }
    //---------------
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Merhaba Dünya");
        rb = this.GetComponent<Rigidbody2D>();
        carpma = this.GetComponent<BoxCollider2D>();

        animasyonDurumu = this.GetComponent<Animator>();

        goruntu = this.GetComponent<SpriteRenderer>();
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
        Debug.Log(xYon);
        rb.velocity = new Vector2(xYon * hiz,rb.velocity.y);
            //Input.GetButtonDown("Horizontal");
    }
    private void ziplama()
    {
        if (Input.GetButtonDown("Jump") && YerdeMi())
        {
            rb.velocity = new Vector2(0,ziplamaHiz);
        }
    }

    private bool YerdeMi()
    {
        //Parametre anlamlarý();
        return Physics2D.BoxCast(carpma.bounds.center, carpma.bounds.size, 0f, Vector2.down,0.2f,katman);
    }

    private void AnimasyonDurumlari()
    {
        bool durum = false;
        Durumlar durumEnum;

        if (xYon == 0)
        {
            //animasyonDurumu.SetBool("Koþma", false);
            durumEnum = Durumlar.bekleme;// 0
        }
        else if (xYon < 0)
        {
            //animasyonDurumu.SetBool("Koþma", true);
            goruntu.flipX = true;
            durumEnum = Durumlar.kosma;//1
        }
        else
        {
            //animasyonDurumu.SetBool("Koþma", true);
            goruntu.flipX = false;
            durumEnum = Durumlar.kosma;//1
        }

        if (rb.velocity.y > 0.1f)
        {
            durumEnum = Durumlar.ziplama;//3
        }
        else if (rb.velocity.y < -0.1f)
        {
            durumEnum = Durumlar.dusme;//2
        }
        /*
         
Karakter dusme Durum: 2
Karakter kosu Durum:1
Karakter Ziplama Durum:3
Karakter idle Durum:0
         */

        animasyonDurumu.SetInteger("Durum",(int) durumEnum);//durum ne ise yollar
    }
}
