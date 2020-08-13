using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kamera_control : MonoBehaviour
{
    public AudioSource bgmusic;
    public Transform topunPozisyonu;
    bool musicVolume = true;

    GameObject musicBut, quitBut , resumeBut , pauseBut;
    // Start is called before the first frame update
    void Start()
    {
        
        musicBut = GameObject.Find("music");
        quitBut = GameObject.Find("quit");
        resumeBut = GameObject.Find("resume");
        pauseBut = GameObject.Find("pause");
        musicBut.gameObject.SetActive(false);
        quitBut.gameObject.SetActive(false);
        resumeBut.gameObject.SetActive(false);
        bgmusic.volume = 0.2f;
        bgmusic.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (topunPozisyonu.position.y>transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, topunPozisyonu.position.y, transform.position.z);
        }
    }

    public void butonsec(int buton)
    {
        if (buton == 0)
        {
            Time.timeScale = 0;
            pauseBut.GetComponent<Button>().interactable = false;
            musicBut.gameObject.SetActive(true);
            quitBut.gameObject.SetActive(true);
            resumeBut.gameObject.SetActive(true);
        }
        else if (buton == 1)
        {
            Time.timeScale = 1;
            pauseBut.GetComponent<Button>().interactable = true;
            musicBut.gameObject.SetActive(false);
            quitBut.gameObject.SetActive(false);
            resumeBut.gameObject.SetActive(false);
        }
        else if (buton == 2)
        {
            musicVolume = !musicVolume;
            if (musicVolume)
            {
                bgmusic.volume = 0.3f;
            }
            else if (!musicVolume)
            {
                bgmusic.volume = 0;
            }
        }
        else if (buton==3)
        {
            Application.Quit();
        }
    }
}
