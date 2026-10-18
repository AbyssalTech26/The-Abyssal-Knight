using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public sealed class Player_Movement : MonoBehaviour
{
    public float speed = 5; //Speed of the player movement
    
    public int facingDirection = 1; //1 for right, -1 for left
    public Rigidbody2D rigidbody; //Reference to the Rigidbody2D component
    public Animator anim; //Reff to the Animator component
    

    //FixedUpdate is called 50x per frame
    void FixedUpdate()
    {
       float horizontal = Input.GetAxis("Horizontal"); //Refering to the axis keys in the project settings (WASD top, left, right, down)
       float vertical = Input.GetAxis("Vertical");

        if(horizontal > 0 && transform.localScale.x < 0 ||
            horizontal < 0 && transform.localScale.x > 0)
        {
            Flip();
        }

        anim.SetFloat("horizontal", Mathf.Abs(horizontal)); //Turns all the negative values to positive values, so that the animation can be played in both directions
        anim.SetFloat("vertical", Mathf.Abs(vertical)); 

        rigidbody.linearVelocity = new Vector2(horizontal,vertical) * speed; // Vector2= (x,y) The way the direction in which we want to move
    }

    void Flip()
    {
        facingDirection *= -1; //Changes the direction of the player
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);//Flips the player sprite by changing the scale of the player object
    }
}
