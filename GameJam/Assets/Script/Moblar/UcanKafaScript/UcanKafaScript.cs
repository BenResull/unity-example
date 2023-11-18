using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UcanKafaScript : MonoBehaviour
{
    public float Can,Hasar,VerilecekEnerji,GorusAlani,Hizi,maxcan,scaleCevir;
    float EskiKonum ;
    public GameObject Player;
    Vector3 direction;
    float Mesafe;
    public PlayerMoveManager PlayerManager;
    public PartikalSystem ParticalSytem;
    bool denetelyi;
    private void Update() 
    {

        Mesafe = Vector2.Distance(transform.position,Player.transform.position);
        direction = transform.position - Player.transform.position;

        float SuAnkiKonumi = transform.position.x;

        if(Mesafe < GorusAlani && !denetelyi)
        {
            transform.position = Vector3.MoveTowards(this.transform.position,Player.transform.position, Hizi * Time.deltaTime);
        }

        if(SuAnkiKonumi < EskiKonum)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1,transform.localScale.y,transform.localEulerAngles.z);
        }

        if(SuAnkiKonumi > EskiKonum)
        {
            transform.localScale = new Vector3(transform.localScale.x * 1,transform.localScale.y,transform.localScale.z);
        }

        if(Can <= 0)
        {
            if(PlayerManager.Enerji < 100)
            {
                PlayerManager.Enerji += VerilecekEnerji;
            }    

            gameObject.SetActive(false);
            ParticalSytem.Basla = true;
        }

        EskiKonum = SuAnkiKonumi;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Can -= 10;
            StartCoroutine(DUR());
        }    
        if(other.gameObject.CompareTag("Finish"))
        {
            PlayerManager.Enerji -= Hasar;
            gameObject.SetActive(false);
            ParticalSytem.Basla = true;
        }
    }

    IEnumerator DUR()
    {
        denetelyi = true;
        yield return new WaitForSeconds(1);
        denetelyi = false;
    }
}
