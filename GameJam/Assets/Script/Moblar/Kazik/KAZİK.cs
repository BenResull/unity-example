using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KAZİK : MonoBehaviour
{
    public float Yukseklik;
    bool denetleyici;

    private void Update()   
    {
        if(!denetleyici)
        {
            StartCoroutine(SAPLA());
        }
    }

    IEnumerator SAPLA()
    {
        denetleyici = true; 
        transform.position = new Vector3(transform.position.x,transform.position.y + Mathf.Lerp(0f,Yukseklik,0.01f),0);
        yield return new WaitForSeconds(2);
        transform.position = new Vector3(transform.position.x,transform.position.y - Mathf.Lerp(Yukseklik,0,0.01f),0);
        yield return new WaitForSeconds(2);
        denetleyici = false;
    }
}
