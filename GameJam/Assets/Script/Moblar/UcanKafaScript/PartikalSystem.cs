using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartikalSystem : MonoBehaviour
{
    public UcanKafaScript UcanKafa;
    public GameObject UcanKafffffa;
    public bool Basla;
    bool Playe;

    private void Update() 
    {
        transform.position = UcanKafffffa.transform.position;
        
        if(Basla)
        {
            if(!Playe)
            {
                GetComponent<ParticleSystem>().Play();
                Playe = true;  
            }
            if(GetComponent<ParticleSystem>().isPlaying == false)
            {
                Destroy(gameObject);
            } 
        }
    } 
}
