using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Sonradan Eklenilen K�t�phane
using UnityEngine.SceneManagement;

//---------------------


public class Karakter_Yasam : MonoBehaviour
{
    Animator animasyonDurumu;
    Rigidbody2D rb;

    private void Start()
    {
        animasyonDurumu = this.GetComponent<Animator>();

        rb = this.GetComponent<Rigidbody2D>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tuzak"))
        {
            
            karakterOlme();
            
        }
    }

    private void karakterOlme()
    {
        animasyonDurumu.SetTrigger("Ölüm");
        rb.bodyType = RigidbodyType2D.Static;

        YenidenBaslat();
    }

    private void YenidenBaslat()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //VEYA
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
