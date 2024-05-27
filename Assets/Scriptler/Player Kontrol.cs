using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerKontrol : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    bool zipla =true;
    bool sagabak = true;
    public float jumpforce;
    float Horizontal;
    Vector3 scale;
    Animator playerAnimator;
    void Start()
    {
      rb = gameObject.GetComponent<Rigidbody2D>(); 
      playerAnimator=GetComponent<Animator>();

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)&&zipla==true)
        {
            rb.AddForce(new Vector2(0,jumpforce));
            zipla=false;
            playerAnimator.SetBool("Jump",true);
        }
        if (Mathf.Approximately(rb.velocity.y,0)&&playerAnimator.GetBool("Jump"))//yaklaşık 0 ise 
        {
            playerAnimator.SetBool("Jump",false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
       {
        if(collision.gameObject.tag=="Platform")
        {
            zipla=true;
        }

       }
    void FixedUpdate()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        playerAnimator.SetFloat("Speed",Mathf.Abs(Horizontal));
        rb.velocity=new Vector3(Horizontal * Time.deltaTime *speed,rb.velocity.y,0);
        if(Horizontal>0 && sagabak==false)
        {
                cevir();
        }
        if(Horizontal<0&&sagabak==true)
        {
                cevir();
        }

    }

    void cevir()
{
    sagabak=!sagabak;
    scale = gameObject.transform.localScale;
    scale.x=scale.x*-1;
    gameObject.transform.localScale=scale;
}


}

