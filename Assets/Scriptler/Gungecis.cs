using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gungecis : MonoBehaviour
{

    public Animator anim;
   
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        StartCoroutine(LoadNextscene());
    }

    IEnumerator LoadNextscene()
    {
        anim.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        Scene scene = SceneManager.GetActiveScene();
        int nextLevelBuildIndex = 1;
        SceneManager.LoadScene(nextLevelBuildIndex);



    }

}
