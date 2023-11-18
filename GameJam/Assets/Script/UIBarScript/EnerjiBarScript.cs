using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnerjiBarScript : MonoBehaviour
{
    public PlayerMoveManager Player;
    public GameObject AzalmaAnim;
    float ENERJI;

    private void Update()
    {
        ENERJI = Player.Enerji / Player.MaxEnerji;
        
        transform.localScale = new Vector3(ENERJI, transform.localScale.y, transform.localScale.z);
        AzalmaAnim.transform.localScale = new Vector3(Mathf.Lerp(AzalmaAnim.transform.localScale.x, ENERJI, 0.01f), 1, 1);

        if (Player.X != 0 && Player.Enerji > 0) 
        {
            Player.Enerji -= 0.1f;
        }
    }
}
