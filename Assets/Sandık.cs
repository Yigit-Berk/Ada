using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Sandık : MonoBehaviour
{
    //public Animator anim;
  public string diyalog;
  public TextMeshProUGUI textI;
   private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")) // gelen obje tagı player ise
        {
            Debug.Log("Sandık Açılsın");
            textI.text = diyalog;
           // anim.SetBool("acikMi",true);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // gelen obje tagı player ise
        {
            //anim.SetBool("acikMi",true);
            Debug.Log("Sandık Kapatıldı");
            textI.text = " ";

        }

    }
    
}
