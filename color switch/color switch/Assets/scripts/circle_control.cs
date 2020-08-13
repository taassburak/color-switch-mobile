using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class circle_control : MonoBehaviour
{
    int randomDonus;
    int randomSayi;
    public float hiz;
    void Start()
    {
        randomSayi = Random.Range(90, 210);
        randomDonus = Random.Range(-1, 2);
        if (randomDonus == 0)
        {
            randomDonus = 1;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Rotate(new Vector3(0,0,randomDonus*randomSayi*Time.deltaTime));
    }
}
