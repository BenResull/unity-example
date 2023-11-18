using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canbar : MonoBehaviour
{
    public UcanKafaScript ucanKafa;
    public GameObject CanAzalmaAniObject;

    private void Start() 
    {
        ucanKafa.maxcan = ucanKafa.Can;
    }

    private void Update() 
    {
        ucanKafa.scaleCevir = ucanKafa.Can / ucanKafa.maxcan;    
        transform.localScale = new Vector3(ucanKafa.scaleCevir,transform.localScale.y,transform.localScale.z);
        CanAzalmaAniObject.transform.localScale = new Vector3(Mathf.Lerp(CanAzalmaAniObject.transform.localScale.x,ucanKafa.scaleCevir,0.3f),CanAzalmaAniObject.transform.localScale.y,CanAzalmaAniObject.transform.localScale.z);
    }
}
