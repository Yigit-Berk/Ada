using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanYurume : MonoBehaviour
{
    public float hiz;
    public Transform[] DusmanHareket;
    private int randomPos;

    void Start()
    {
        randomPos = Random.Range(0, DusmanHareket.Length);
    }

    void Update()
    {

        Vector2 direction = DusmanHareket[randomPos].position - transform.position;


        if (direction.x > 0)
        {

            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (direction.x < 0)
        {

            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }


        transform.position = Vector2.MoveTowards(
            transform.position,
            DusmanHareket[randomPos].position,
            hiz * Time.deltaTime
        );


        if (Vector2.Distance(transform.position, DusmanHareket[randomPos].position) < 0.2f)
        {
            randomPos = Random.Range(0, DusmanHareket.Length);
        }
    }
}