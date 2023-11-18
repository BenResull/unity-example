using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    bool YOKET;
    public float suree; 

    private void Update() 
    {
        if(!YOKET)
        {
            StartCoroutine(YokEt(suree));
        }    
    }

    IEnumerator YokEt(float sure)
    {
        YOKET = true;
        yield return new WaitForSeconds(sure);
        Destroy(gameObject);
    }
}
