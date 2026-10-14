using Unity.AppUI.UI;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float speed = 5; //Speed of the player movement
    public Rigidbody2D rigidbody; //Reference to the Rigidbody2D component

    //FixedUpdate is called 50x per frame
    void FixedUpdate()
    {
       float horizontal = Input.GetAxis("Horizontal"); //Refering to the axis keys in the project settings (WASD top, left, right, down)
       float vertical = Input.GetAxis("Vertical");

        rigidbody.linearVelocity = new Vector2(horizontal,vertical) * speed; // Vector2= (x,y) The way the direction in which we want to move
    }
}
