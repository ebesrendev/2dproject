using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterHareket: MonoBehaviour
{   //Burda karaktere verdiðimiz özelliklere referans veriyoruz ki kod üstünde rahat kullanalým
    Rigidbody2D rgb;
    Vector3 velocity;
    

    //verdiðimiz hareketlerin deðerlerini ayarlýyoruz
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
        //yürüme ayarlarý
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f);
        transform.position += velocity * speedAmount * Time.deltaTime;
        
        //zýplama ayarý
        if (Input.GetButtonDown("Jump") && Mathf.Approximately(rgb.velocity.y, 0))

        {
            rgb.AddForce(Vector3.up * jumpAmount, ForceMode2D.Impulse);
           
        }
        
        //karakterin kamera bakýs acýsýný deðiþtirme
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
