using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaHareket : MonoBehaviour
{
    [SerializeField] GameObject gemiyeCarpan;
    [SerializeField] GameObject diyalog;
    
    // Start is called before the first frame update
    void Start()
    {
        gemiyeCarpan = this.gameObject;
    }
    
    // Update is called once per frame
    void Update()
    {
        //Ada Gemiye doðru yaklaþýr
        gemiyeCarpan.transform.Translate(new Vector3(-1 * Time.deltaTime, 0, 0)); // Time.deltaTime kullanarak her frame'de -1 birim hareket et
    }

    /*kinematic rigidbody'ye sahip olan Gemi ("Zemin katmaný") Tagli nesneye çarpma anýnda yapýlacaklar*/
    private void OnCollisionEnter2D(Collision2D collision)//çarpýþma anýnda
    {
        if (collision.gameObject.CompareTag("Gemi"))
        {
            Debug.Log("ADA GÖrüldü");
            Destroy(this.gameObject);

            // Canvas'ý görünmez yap
            if (diyalog != null)
            {
                diyalog.SetActive(true);
            }

        }
    }

}
