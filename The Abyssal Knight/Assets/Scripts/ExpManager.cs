using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExpManager : MonoBehaviour
{
    public int level;
    public int currentExp;
    public int expToLevel = 10;
    public float expGrowthMultiplier = 1.2f; //The multiplier for how much exp is needed for the next level
    public Slider expSlider; //Reference to the UI slider that shows the player's exp
    public TMP_Text currentLevelText;

    private void Start()
    {
        UpdateUI();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) //For testing purposes, press L to gain exp
        {
            GainExperiance(2);
        }
    }

    private void OnEnable() //Listens for when an enemy dies 
    {
        Enemy_Health.OnMonsterDefeated += GainExperiance; //Dead enemy sends out this message to set course of exp gain 
    }
    private void OnDisable()
    {
        Enemy_Health.OnMonsterDefeated -= GainExperiance;
    }
    public void GainExperiance(int amount)
    {
        currentExp += amount;
        if (currentExp >= expToLevel)
        {
            LevelUp();
        }

        UpdateUI();
    }

    private void LevelUp() //Level made into its own method to heed to seperaration of concerns
    {
        level++;
        currentExp -= expToLevel;
        expToLevel = Mathf.RoundToInt(expToLevel * expGrowthMultiplier);
    }

    public void UpdateUI()
    {
        expSlider.maxValue = expToLevel;
        expSlider.value = currentExp;
        currentLevelText.text = "Level: " + level;
    }
}
