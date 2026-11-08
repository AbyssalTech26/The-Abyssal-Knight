using UnityEngine;

[CreateAssetMenu(fileName = "NewSkill", menuName = "Skill Tree/Skill")]
public class SkillSO : ScriptableObject
{
    //Is not a monobehavior. Monobehaviors = Stores on game objects and generally control behaviours
    // Scriptable Objects = Live outside scene and r effeciant for storing and sharing data

    public string skillName;
    public int maxLevel;
    public Sprite skillIcon;

}
