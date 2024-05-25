using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaHareket : MonoBehaviour
{
    [SerializeField] GameObject gemiyeCarpan;
    [SerializeField] GameObject diyalog;
    public bool adaDurum=true;
    
    // Start is called before the first frame update
    void Start()
    {
        gemiyeCarpan = this.gameObject;
    }
    
    // Update is called once per frame
    void Update()
    {
        //Ada Gemiye doðru yaklaþýr
        adaHareket();
    }

    /*kinematic rigidbody'ye sahip olan Gemi ("Zemin katmaný") Tagli nesneye çarpma anýnda yapýlacaklar*/
    private void OnCollisionEnter2D(Collision2D collision)//çarpýþma anýnda
    {
        if (collision.gameObject.CompareTag("Gemi"))
        {
            Debug.Log("ADA GÖrüldü");
            adaDurum= false;
            // Canvas'ý görünmez yap
            if (diyalog != null)
            {
                diyalog.SetActive(true);
            }

        }
    }

     void adaHareket (){
        if (adaDurum)
        {
            gemiyeCarpan.transform.Translate(new Vector3(-1 * Time.deltaTime, 0, 0)); 
            // Time.deltaTime kullanarak her frame'de -1 birim hareket et
        }
        else
        {
            //ada dursun
            gemiyeCarpan.transform.Translate(new Vector3(0, 0, 0));
        }
    }
    
    public void AdaDurumTrue()
    {
        adaDurum= true;
        // Canvas'ý görünmez yap
        if (diyalog != null)
        {
            diyalog.SetActive(false);
        }
    }

    /*buton tarafýndan karar verilecek ada giriþ kodlarý*/
    public void Ada1()
    {

    }
    public void Ada2()
    {

    }
}
