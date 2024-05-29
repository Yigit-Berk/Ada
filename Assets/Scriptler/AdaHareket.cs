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

    private void Awake()
    {
        diyalog.SetActive(false);//olu�turulma an�nda g�r�nmez olsun
    }

    // Start is called before the first frame update
    void Start()
    {
        gemiyeCarpan = this.gameObject;
        aktifAdaSahnesi = this.gameObject.name;//�arpan nesnenin ad�n� ata
        
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
            aktifAdaSahnesi = gemiyeCarpan.name;

            Debug.Log("aktif sahne: "+aktifAdaSahnesi);

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
            gemiyeCarpan.transform.Translate(Vector3.zero);
        }
    }
    
    public void ButonHayir()
    {
        adaDurum= true;
        // Canvas'� g�r�nmez yap
        if (diyalog != null)
        {
            diyalog.SetActive(false);
        }
        


    }

    public void ButonEvet()
    {
        Debug.Log("Evet Tu�land�");
        

        adaDurum = true;
        // Canvas'� g�r�nmez yap
        if (diyalog != null)
        {
            diyalog.SetActive(false);
        }
        //SceneManager.LoadScene(aktifAdaSahnesi[indis]);//indise g�re ada sahnesine git

        aktifAdaSahnesi = null;
        aktifAdaSahnesi = gemiyeCarpan.name;
        SceneManager.LoadScene(aktifAdaSahnesi);//ada ad�na g�re sahneyi y�kler

        Debug.Log("ol loooo ol"+aktifAdaSahnesi);
    }

    /*buton taraf�ndan karar verilecek ada giri� kodlar�*/

    private void SonrakiBolum()
    {
        //SceneManager.LoadScene(aktifAdaSahnesi[indis]);
        //SceneManager.LoadScene(aktifAdaSahnesi);

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //SceneManager.GetActiveScene().ToString();
    }
}
