using UnityEngine;

public class Enemy_Combat : MonoBehaviour
{
    public int damage = 2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<PlayerHealth>().ChangeHealth(-damage);
    }
}
