using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterHareket : MonoBehaviour

{
    Rigidbody2D rgb;
    Vector3 velocity;
   

    //verdiðimiz hareketlerin deðerlerini ayarlýyoruz
    float speedAmount = 10f;
    float jumpAmount = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //yürüme ayarlarý
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f);
        transform.position += velocity * speedAmount * Time.deltaTime;
        if (Input.GetButtonDown("Jump") && Mathf.Approximately(rgb.velocity.y, 0))

        {
            rgb.AddForce(Vector3.up * jumpAmount, ForceMode2D.Impulse);
            
        }
        
    }
}
