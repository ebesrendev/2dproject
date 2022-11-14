using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HareketV2 : MonoBehaviour
{
    private float movementDirection;
    public float movementForce;
    public float maxHorizontalMovmentSpeed;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
         
        movementDirection = Input.GetAxis("Horizontal");
    }


    private void FixedUpdate()
    {
        Vector2 forceToAdd = new Vector2(movementForce * movementDirection, 0);
        rb.AddForce(forceToAdd);
    }
}
