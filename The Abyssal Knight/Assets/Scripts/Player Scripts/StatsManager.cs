using UnityEngine;

public class StatsManager : MonoBehaviour
{
    //Singleton Pattern: A coding patter that gives easy access to other scripts , and has only one "instance" of the script in the scene
    //static: varibales with only one instance. Unlike normal varibales (ie. enemy "health") that can have multiple instances for each enemy
    public static StatsManager Instance;
    
    [Header("Combat Stats")]
    public int damage;
    public float weaponRange;
    public float knockbackForce;
    public float knockbackTime;
    public float stunTime;

    [Header("Movement Stats")]
    public int speed;

    [Header("Health Stats")]
    public int maxHealth;
    public int currentHealth;

    private void Awake()//Awake called before Start()
    {
       if(Instance == null)//If there is no instance of this script in the scene
        {
            Instance = this;//Set the instance to this script
        }
        else//If there is already an instance of this script in the scene
        {
            Destroy(gameObject);//Destroy this script
        }
    }
}
