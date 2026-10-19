using UnityEngine;

public sealed class Enemy_Movement : MonoBehaviour
{
    public float speed;
    private bool isChasing;
    private Rigidbody2D rb; // to talk to eneymy physics, private in order to spawn into the game at run time dynamically
    private Transform player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //Game obeject looks at itself for its rigid body component
    }

    void Update()
    {
        if (isChasing == true) //Enemy will only chase if this value is true
        {
            Vector2 direction = (player.position - transform.position).normalized; //Difference betwen P n E to get movement. Issue, speed may be effected by large differences.
                                                                                   //Solution: normalized uses speed to control how fast the enemy  moves 
            rb.linearVelocity = direction * speed;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (player == null)
            {
                player = collision.transform;
            }
                isChasing = true;
           
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rb.linearVelocity = Vector2.zero;
            isChasing = false;
        }
    }
}
