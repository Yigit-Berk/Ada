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
        //Ada Gemiye doðru yaklaþýr
        gemi.transform.Translate(new Vector3(-1 * Time.deltaTime, 0, 0)); // Time.deltaTime kullanarak her frame'de -1 birim hareket et
    }

    /*kinematic rigidbody'ye sahip olan Gemi ("Zemin katmaný") Tagli nesneye çarpma anýnda yapýlacaklar*/
    private void OnCollisionEnter2D(Collision2D collision)//çarpýþma anýnda
    {
        if (collision.gameObject.CompareTag("Gemi"))
        {
            diyalog.enabled = true;
            Debug.Log("ADA GÖrüldü");
            //Destroy(gameObject);
        }
    }

}
