using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TkerarDeneButton : MonoBehaviour
{
    public void TerkarDene()
    {
        int aktifSahneIndeksi = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(aktifSahneIndeksi);
    }
}
