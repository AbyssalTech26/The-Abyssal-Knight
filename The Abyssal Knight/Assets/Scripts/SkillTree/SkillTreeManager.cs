
using UnityEngine;
using TMPro;

public class SkillTreeManager : MonoBehaviour
{
    public SkillSlot[] skillSlots;
    public TMP_Text pointsTexts;
    public int availablePoints;

    private void Start()
    {
        foreach (SkillSlot slot in skillSlots)
        {
            slot.skillButton.onClick.AddListener(slot.TryUpgradeSkill);
        }
    }


    public void UpdateAbilityPoint(int amount)
    {
        availablePoints += amount;
        pointsTexts.text = "Points: " + availablePoints;
    }
}
