using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdaHareket : MonoBehaviour
{
    public GameObject gemiyeCarpan;
    [SerializeField] GameObject diyalog;
    public bool adaDurum=true;
    public string[] aktifAdaSahnesi;
    private int indis=0;
    
    // Start is called before the first frame update
    void Start()
    {
        gemiyeCarpan = this.gameObject;
        aktifAdaSahnesi = new string[4];
        aktifAdaSahnesi[0] = this.gameObject.name;//�arpan nesnenin ad�n� ata
        aktifAdaSahnesi[1] = "ada2";
        aktifAdaSahnesi[2] = "ada3";
        aktifAdaSahnesi[3] = "ada4";

    }
    
    // Update is called once per frame
    void Update()
    {
        //Ada Gemiye do�ru yakla��r
        adaHareket();
    }

    /*kinematic rigidbody'ye sahip olan Gemi ("Zemin katman�") Tagli nesneye �arpma an�nda yap�lacaklar*/
    private void OnCollisionEnter2D(Collision2D collision)//�arp��ma an�nda
    {
        
        if (collision.gameObject.CompareTag("Gemi"))
        {
            aktifAdaSahnesi[0] = this.gameObject.name;//�arpan nesnenin ad�n� ata
            //Debug.Log("ADA G�r�ld�");
            adaDurum = false;
            // Canvas'� g�r�nmez yap
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
    
    public void ButonHay�r()
    {
        adaDurum= true;
        // Canvas'� g�r�nmez yap
        if (diyalog != null)
        {
            diyalog.SetActive(false);
        }
        //indis++;

    }

    public void ButonEvet()
    {
        Debug.Log("Evet Tu�land�");
        Debug.Log(aktifAdaSahnesi[0].ToString());

        adaDurum = true;
        // Canvas'� g�r�nmez yap
        if (diyalog != null)
        {
            diyalog.SetActive(false);
        }
        //SceneManager.LoadScene(aktifAdaSahnesi[indis]);//indise g�re ada sahnesine git


        //SceneManager.LoadScene(aktifAdaSahnesi[0]);//ada ad�na g�re sahneyi y�kler
        Debug.Log(aktifAdaSahnesi[0]);
    }

    /*buton taraf�ndan karar verilecek ada giri� kodlar�*/

    private void SonrakiBolum()
    {
        //SceneManager.LoadScene(aktifAdaSahnesi[indis]);
        SceneManager.LoadScene(aktifAdaSahnesi[0]);

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //SceneManager.GetActiveScene().ToString();
    }
}
