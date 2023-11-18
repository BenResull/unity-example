using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMoveManager : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float jumpSpeed;
    Animator anim;
    public float X;
    bool ZiplamaOnay;
    public float Enerji;
    public float MaxEnerji;
    public GameObject HasarAlani;
    int sahne = 1;
    public GameObject DeathPanel;
    bool denetleyici;
    public AudioClip YurumeSes;
    public AudioClip ZiplamaVurmaSes;
    AudioSource SesCal;
    

    private void Start() 
    {
        SesCal = GetComponent<AudioSource>();
        Time.timeScale = 1;
        DeathPanel.SetActive(false);
        MaxEnerji = Enerji;
        rb = GetComponent<Rigidbody2D>();    
        anim = GetComponent<Animator>();
        HasarAlani.SetActive(false);
    }

    private void FixedUpdate() 
    {
        X = Input.GetAxisRaw("Horizontal");

        if(Enerji > 0)
        {
            rb.velocity = new Vector2(X * speed * Time.deltaTime,rb.velocity.y);
            if(X != 0)
            {
                if(SesCal.isPlaying == false && ZiplamaOnay)
                {
                    SesCal.clip = YurumeSes;
                    SesCal.Play();
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.Space) && ZiplamaOnay && Enerji > 0 && X != 0 || Input.GetKeyDown(KeyCode.Space) && ZiplamaOnay && Enerji > 0 && X == 0)
        {
            ZiplamaOnay = !ZiplamaOnay;
            anim.SetInteger("KosZiplaDur",2);
            rb.velocity = Vector2.up * jumpSpeed * Time.deltaTime;
            transform.parent = null;
            if(SesCal.isPlaying == false)
            {
                SesCal.clip = ZiplamaVurmaSes;
                SesCal.Play();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Zemin") && !ZiplamaOnay && Enerji > 0 || other.gameObject.CompareTag("f5") && !ZiplamaOnay && Enerji > 0)
        {
            ZiplamaOnay = !ZiplamaOnay;
            Debug.Log(ZiplamaOnay);
            anim.SetInteger("KosZiplaDur",0);
        }    
        if(other.gameObject.CompareTag("f5") && Enerji > 0)
        {
            transform.parent = other.gameObject.transform;
        }
        if(other.gameObject.CompareTag("Kazik"))
        {
            DeathPanel.SetActive(true);
            this.enabled = false;
        }   
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Portal"))
        {
            int aktifSahneIndeksi = SceneManager.GetActiveScene().buildIndex;
            aktifSahneIndeksi ++;
            SceneManager.LoadScene(aktifSahneIndeksi);
        }
    }

    private void Update() 
    {
        if(X > 0 && ZiplamaOnay && Enerji > 0 && !denetleyici || X < 0 && ZiplamaOnay && Enerji > 0 && !denetleyici)
        {
            anim.SetInteger("KosZiplaDur",1);
        }  
        if(X == 0 && ZiplamaOnay && Enerji > 0 && !denetleyici)
        {
            anim.SetInteger("KosZiplaDur",0);
        }  
        if(X == 1 && Enerji > 0)
        {
            transform.localScale = new Vector3(1,1,1);
        }
        if(X == -1 && Enerji > 0)
        {
            transform.localScale = new Vector3(-1,1,1);
        }
        if(Input.GetKeyDown(KeyCode.Mouse0) && !denetleyici)
        {
            StartCoroutine(VUR());
        }
        if(transform.position.y < -25)
        {
            DeathPanel.SetActive(true);
            this.enabled = false;
        }
        if(Enerji <= 0)
        {
            DeathPanel.SetActive(true);
            this.enabled = false;
        }
    }

    IEnumerator VUR()
    {
        denetleyici = true;
        HasarAlani.SetActive(true);
        anim.SetInteger("KosZiplaDur",3);
        SesCal.clip = ZiplamaVurmaSes;
        SesCal.Play();
        yield return new WaitForSeconds(0.3f);
        HasarAlani.SetActive(false);
        anim.SetInteger("KosZiplaDur",0);
        denetleyici = false;
    }
}
