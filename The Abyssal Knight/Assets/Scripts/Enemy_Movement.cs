using Newtonsoft.Json.Bson;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.XR;

public class Enemy_Movement : MonoBehaviour
{
    public float speed;
    private bool isChasing;
    private int facingDirection = -1;
    private EnemyState enemyState;
    public float attackRange = 2; // The range at which the enemy will attack the player
    private Rigidbody2D rb;
    private Transform player;
    private Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ChangeState(EnemyState.Idle);
    }

    void Update()
    {
        if (enemyState == EnemyState.Chasing)
        {
            Chase();
        }
        else if (enemyState ==EnemyState.Attacking)
        { 
            //Attack stuff here
        }
    }

    void Chase()
    {
        if(Vector2.Distance (transform.position, player.transform.position) <= attackRange)
        {
            ChangeState(EnemyState.Attacking);
            
        }
        else if (player.position.x > transform.position.x && facingDirection == -1 ||
                    player.position.x < transform.position.x && facingDirection == 1)
        {
            Flip();
        }
        Vector2 direction = (player.position - transform.position).normalized;
        rb.linearVelocity = direction * speed;
    }

    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (player == null)
            {
                player = collision.transform;
            }
            ChangeState(EnemyState.Chasing);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {  
        rb.linearVelocity = Vector2.zero;
        ChangeState(EnemyState.Idle);
        }
    }
    void ChangeState(EnemyState newState)
    {
        //Exit the current animation state
        if (enemyState == EnemyState.Idle)
            anim.SetBool("isIdle", false);
        else if (enemyState == EnemyState.Chasing)
            anim.SetBool("isChasing", false);
        else if (enemyState == EnemyState.Attacking)
            anim.SetBool("isAttacking", false);

        //Update our current state
        enemyState = newState;

        //Update the new animation
        if (enemyState == EnemyState.Idle)
            anim.SetBool("isIdle", true);
        else if (enemyState == EnemyState.Chasing)
            anim.SetBool("isChasing", true);
        else if (enemyState == EnemyState.Attacking)
            anim.SetBool("isAttacking", true);
    }
}
//StateMachine =  Used for the enemy to switch between different states, such as idle and chasing the player.
public enum EnemyState
{
    Idle, 
    Chasing,
    Attacking,
}
