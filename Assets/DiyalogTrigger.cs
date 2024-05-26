using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DiyalogKarakter
{
    public string isim;
    public Sprite icon;
}

[System.Serializable]
public class DiyalogAlani
{
    //text area ile diyalog alanlar� belirlenir
    public DiyalogKarakter karakter;
    [TextArea(3, 10)]
    public string satir;
}

[System.Serializable]
public class Dialogue
{
    public List<DiyalogAlani> diyalogSatirlari = new List<DiyalogAlani>();
}


/*
 DiyalogTrigger:
NPC ile etkile�im durumunda �al��acak diyalog kutular�n� ve ba�l�klar�n� i�erir.

 */
public class DiyalogTrigger : MonoBehaviour
{
    public Dialogue diyalog;

    public void TriggerDiyalog()
    {
        DiyalogYonetimi.Instance.DiyalogBaslat(diyalog);//di�er scriptteki diyalo�u ba�lat
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("Trigger �al��t�");
            TriggerDiyalog();
        }
    }
}


