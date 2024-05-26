using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdaHareket : MonoBehaviour
{
    public GameObject gemiyeCarpan;
    [SerializeField] GameObject diyalog;
    public bool adaDurum=true;
    public string aktifAdaSahnesi;
    
    // Start is called before the first frame update
    void Start()
    {
        gemiyeCarpan = this.gameObject;
        aktifAdaSahnesi = this.gameObject.name;//çarpan nesnenin adýný ata
        
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
            aktifAdaSahnesi = this.gameObject.name;//çarpan nesnenin adýný ata
            //Debug.Log("ADA GÖrüldü");
            adaDurum = false;
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
    
    public void ButonHayýr()
    {
        adaDurum= true;
        // Canvas'ý görünmez yap
        if (diyalog != null)
        {
            diyalog.SetActive(false);
        }
        //indis++;

    }

    public void ButonEvet()
    {
        Debug.Log("Evet Tuþlandý");
        Debug.Log(aktifAdaSahnesi.ToString());

        adaDurum = true;
        // Canvas'ý görünmez yap
        if (diyalog != null)
        {
            diyalog.SetActive(false);
        }
        //SceneManager.LoadScene(aktifAdaSahnesi[indis]);//indise göre ada sahnesine git


        //SceneManager.LoadScene(aktifAdaSahnesi[0]);//ada adýna göre sahneyi yükler
        Debug.Log(aktifAdaSahnesi);
    }

    /*buton tarafýndan karar verilecek ada giriþ kodlarý*/

    private void SonrakiBolum()
    {
        //SceneManager.LoadScene(aktifAdaSahnesi[indis]);
        SceneManager.LoadScene(aktifAdaSahnesi);

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //SceneManager.GetActiveScene().ToString();
    }
}
