using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DusmanYurume : MonoBehaviour
{
    // Start is called before the first frame update

    public float hiz;

    public Transform[] DusmanHareket;

    private int randomPos;

    void Start()
    {
        randomPos = Random.Range(0, DusmanHareket.Length);

    }

    // Update is called once per frame
    void Update()
    {
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
