using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaHareket : MonoBehaviour
{
    [SerializeField] GameObject gemiyeCarpan;
    [SerializeField] GameObject diyalog;
    private bool adaDurum=true;
    
    // Start is called before the first frame update
    void Start()
    {
        gemiyeCarpan = this.gameObject;
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
            Debug.Log("ADA G�r�ld�");
            adaDurum= false;
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

}