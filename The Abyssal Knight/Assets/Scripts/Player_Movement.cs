using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public sealed class PlayerMovement : MonoBehaviour
{
    public float speed = 5; //Speed of the player movement
    
    public int facingDirection = 1; //1 for right, -1 for left
    public Rigidbody2D rigidbody; //Reference to the Rigidbody2D component
    public Animator anim; //Reff to the Animator component
    private bool isKnockedBack;


    //FixedUpdate is called 50x per frame
    void FixedUpdate() //Movement Logic
    {
        if (isKnockedBack == false)
        {
            float horizontal = Input.GetAxis("Horizontal"); //Refering to the axis keys in the project settings (WASD top, left, right, down) 
            float vertical = Input.GetAxis("Vertical");

            if (horizontal > 0 && transform.localScale.x < 0 ||
                horizontal < 0 && transform.localScale.x > 0)
            {
                Flip();
            }

            anim.SetFloat("horizontal", Mathf.Abs(horizontal)); //Turns all the negative values to positive values, so that the animation can be played in both directions
            anim.SetFloat("vertical", Mathf.Abs(vertical));

            rigidbody.linearVelocity = new Vector2(horizontal, vertical) * speed; // Vector2= (x,y) The way the direction in which we want to move
        }
    }

    void Flip()
    {
        facingDirection *= -1; //Changes the direction of the player
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);//Flips the player sprite by changing the scale of the player object
    }

    public void Knockback(Transform enemy, float force, float stunTime)
    {
        isKnockedBack = true; //Diables player movement
        Vector2 direction = (transform.position - enemy.position).normalized; //Direction playern will be sent 
        rigidbody.linearVelocity = direction * force; //Force applied to the player when knocked back
        StartCoroutine(KnockbackCounter(stunTime)); //Work like methods, except that they can be paused (therefore using for timer)
    }

    IEnumerator KnockbackCounter(float stunTime) //Using a coroutine to make a limit amount of time of knockback 
    {
        yield return new WaitForSeconds(stunTime); //Wait 1 sec before switching off knockback 
        rigidbody.linearVelocity = Vector2.zero;
        isKnockedBack = false;
    }
}
