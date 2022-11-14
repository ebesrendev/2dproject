using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HareketV2 : MonoBehaviour
{
    //zýplama ile ilgili

    public Transform top_left;
    public Transform bottom_right;
    public LayerMask groundLayers;
    private bool grounded;
    public Vector2 jumpHeight;





    //hareket ile ilgili deðiþkenler
    private float movementDirection;
    public float movementForce;
    private bool isFacingRight = true;
    public float maxHorizontalMovmentSpeed;
    private Vector2 velocity;
    [Range(0, 1)] public float groundFrictionLevel;
    private Rigidbody2D rb;

    void Start()
    {

        //hareket
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
         //hareket girdiyi al
        movementDirection = Input.GetAxisRaw("Horizontal");

        //zýplama girdisi
        if (Input.GetKeyDown(KeyCode.Space) && grounded)  //makes player jump
        {
            GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);

            grounded = false;
        }


        //yüzünü dönmek için yönü belirle
        if (isFacingRight && movementDirection < 0)
        {
            Flip();

        }else if(!isFacingRight && movementDirection > 0)
        {
            Flip();
        }




    }


    private void FixedUpdate()
    {

        //zýplama
        
        grounded = Physics2D.OverlapArea(top_left.position, bottom_right.position, groundLayers);


        //yürüme ile ilgili

        Vector2 forceToAdd = new Vector2(movementForce * movementDirection, 0);
        rb.AddForce(forceToAdd, ForceMode2D.Impulse);

        if(rb.velocity.x > maxHorizontalMovmentSpeed)
        {
            rb.velocity = new Vector2(maxHorizontalMovmentSpeed, rb.velocity.y);
        }else if(rb.velocity.x < -maxHorizontalMovmentSpeed)
        {
            rb.velocity = new Vector2(-maxHorizontalMovmentSpeed, rb.velocity.y);
        }


        if(movementDirection == 0)
        {
            velocity = rb.velocity;
            velocity.x *= groundFrictionLevel;
            rb.velocity = velocity;
        }
    }




    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0.0f, 180f, 0f);
    }

}
