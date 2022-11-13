using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterHareket: MonoBehaviour
{   //Burda karaktere verdi�imiz �zelliklere referans veriyoruz ki kod �st�nde rahat kullanal�m
    Rigidbody2D rgb;
    Vector3 velocity;
    

    //verdi�imiz hareketlerin de�erlerini ayarl�yoruz
    [SerializeField]
    private float speedAmount = 5f;
    [SerializeField]
    private float jumpAmount = 4.9f;


    void Start()
    {
        //Burda rgb elde ediyoruz
        rgb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        //y�r�me ayarlar�
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f);
        transform.position += velocity * speedAmount * Time.deltaTime;
        
        //z�plama ayar�
        if (Input.GetButtonDown("Jump") && Mathf.Approximately(rgb.velocity.y, 0))

        {
            rgb.AddForce(Vector3.up * jumpAmount, ForceMode2D.Impulse);
           
        }
        
        //karakterin kamera bak�s ac�s�n� de�i�tirme
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }


}
