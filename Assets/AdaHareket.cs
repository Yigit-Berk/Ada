using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaHareket : MonoBehaviour
{
    [SerializeField] GameObject gemi;
    [SerializeField] Canvas diyalog;
    // Start is called before the first frame update
    void Start()
    {
        gemi = this.gameObject;
        diyalog = GetComponent<Canvas>();
    }
    
    // Update is called once per frame
    void Update()
    {
        //Ada Gemiye do�ru yakla��r
        gemi.transform.Translate(new Vector3(-1 * Time.deltaTime, 0, 0)); // Time.deltaTime kullanarak her frame'de -1 birim hareket et
    }

    /*kinematic rigidbody'ye sahip olan Gemi ("Zemin katman�") Tagli nesneye �arpma an�nda yap�lacaklar*/
    private void OnCollisionEnter2D(Collision2D collision)//�arp��ma an�nda
    {
        if (collision.gameObject.CompareTag("Gemi"))
        {
            diyalog.enabled = true;
            Debug.Log("ADA G�r�ld�");
            //Destroy(gameObject);
        }
    }

}
