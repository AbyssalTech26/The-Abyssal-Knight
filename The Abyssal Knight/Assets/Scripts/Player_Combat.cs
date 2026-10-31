using UnityEngine;

public class Player_Combat : MonoBehaviour
{
    public Transform attackPoint;//Attack origin point
    public float weaponRange = 1;
    public LayerMask enemyLayer;//what an enemy is
    public int damage = 1;

    
    public Animator anim;
    public float cooldown = 2;
    private float timer;

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    public void Attack()
    {
        if(timer <= 0)
        anim.SetBool("isAttacking", true); //When calling attack, animator set bool to true  
        timer = cooldown;
    }

    public void DealDamage()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, enemyLayer); //Collides with enemy.
                                                                                                          //Cicle parameters would be: 1.Origin Ppint, 2.Cirlce Radius, 3.Layer to check for 

        if (enemies.Length > 0)//if there is 1 enemy, deal damagew to enemy 0(first in the list of array)
        {
            enemies[0].GetComponent<Enemy_Health>().ChnageHealth(-damage);//if Enemy_Health script is on a child of an Enemy use: "GetComponentInChildren<>()" instead
        }
    }

    public void FinishAttacking()
    {
        anim.SetBool("isAttacking", false);
    }

    /*private void OnDrawgGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, weaponRange);
    }*/
}
