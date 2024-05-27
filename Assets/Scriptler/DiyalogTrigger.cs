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
    //text area ile diyalog alanlarý belirlenir
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
NPC ile etkileþim durumunda çalýþacak diyalog kutularýný ve baþlýklarýný içerir.

 */
public class DiyalogTrigger : MonoBehaviour
{
    public Dialogue diyalog;

    public void TriggerDiyalog()
    {
        DiyalogYonetimi.Instance.DiyalogBaslat(diyalog);//diðer scriptteki diyaloðu baþlat
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("Trigger Çalýþtý");
            TriggerDiyalog();
        }
    }
}


