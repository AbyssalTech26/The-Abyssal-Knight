using UnityEngine;

public sealed class Enemy_Combat : MonoBehaviour
{
    public int damage = 2;
    public Transform attackPoint;
    public float weaponRange;
    public float knockbckForce;
    public float stunTime;
    public LayerMask playerLayer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().ChangeHealth(-damage);
        }
    }
    public void Attack() //Attack Logic
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, playerLayer); //Check for player
        if (hits.Length > 0)
        {
            hits[0].GetComponent<PlayerHealth>().ChangeHealth(-damage); //Deals damage to player 
            hits[0].GetComponent<PlayerMovement>().Knockback(transform, knockbckForce, stunTime);
        }
    }
}
