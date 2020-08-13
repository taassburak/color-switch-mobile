using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ball_control : MonoBehaviour
{
    string renk;
    public float ziplama;
    Rigidbody2D fizik;
    Color color;
    public Color turkuaz;
    public Color sari;
    public Color mor;
    public Color pembe;
    static int skor = 0;
    public GameObject[] cemberler;
    public GameObject RenkTekeri;
    GameObject mesafe;
    public Text scoreText;
    private static int highscore = 0;
    public Text highscoreText;

    void Start()
    {
        randomRenk();

        fizik = GetComponent<Rigidbody2D>();

        highscoreText.text = "HIGH SCORE : "+PlayerPrefs.GetInt("HighScore").ToString();
        scoreText.text = "SCORE : " + skor;
        
    }


    void Update()
    {
        highscoreText.text = "HIGH SCORE : " + PlayerPrefs.GetInt("HighScore").ToString();

        if (PlayerPrefs.GetInt("HighScore")<skor)
        {
            PlayerPrefs.SetInt("HighScore", skor);
            highscoreText.text = "HIGH SCORE : "+PlayerPrefs.GetInt("HighScore").ToString();
        }
        mesafe = GameObject.FindGameObjectWithTag("respawn");

        if (Input.touchCount>0)
        {
            
            Vector3 vec = new Vector3(0, ziplama, 0);
            fizik.velocity = vec;
            
        }




    }

    void randomRenk()
    {
        int randomSayi = Random.Range(0, 4);

        if (randomSayi == 0)
        {
            renk = "turkuaz";
            //color = new Color(34, 231, 218);
            color = turkuaz;
        }
        else if (randomSayi == 1)
        {
            renk = "sarı";
            //color = new Color(255,255,0);
            color = sari;
        }
        else if (randomSayi == 2)
        {
            renk = "pembe";
            //color = new Color(255, 0, 196);
            color = pembe;
        }
        else if (randomSayi == 3)
        {
            renk = "mor";
            //color = new Color(151, 0, 255);
            color = mor;
        }
        GetComponent<SpriteRenderer>().color = color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "renkdegistirme")
        {
            randomRenk();
            Instantiate(RenkTekeri, new Vector3(transform.position.x, mesafe.transform.position.y + 2.5f, transform.position.z), transform.rotation);
            Destroy(collision.gameObject);
            return;
        }

        if (collision.tag == "skoruArttir")
        {
            skor += 10;
            scoreText.text ="SCORE : "+skor.ToString();
            
            Destroy(collision.gameObject);
            return;
        }
        if (collision.tag == "respawn")
        {
            int randomCember = Random.Range(0, 3);
            Instantiate(cemberler[randomCember], new Vector3(transform.position.x, transform.position.y + 7.8f, transform.position.z), transform.rotation);
            Destroy(collision.gameObject);
            return;
        }

        if (collision.tag != renk)
        {
            skor = 0;
            scoreText.text ="SCORE : "+skor.ToString();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
       


    }
}

   
